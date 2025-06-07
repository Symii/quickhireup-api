using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using quickhireup_api.Application.DTOs;
using quickhireup_api.Application.Services;
using quickhireup_api.Models;

namespace quickhireup_api.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AccountController : ControllerBase
{
    private readonly UserManager<User> userManager;
    private readonly SignInManager<User> signInManager;
    private readonly IJwtService jwtService;

    public AccountController(UserManager<User> userManager, SignInManager<User> signInManager, IJwtService jwtService)
    {
        this.userManager = userManager;
        this.signInManager = signInManager;
        this.jwtService = jwtService;
    }
    
    [HttpPost("register")]
    public async Task<IActionResult> Register(UserRegisterDto dto)
    {
        var existingUser = await userManager.FindByEmailAsync(dto.Email);
        if (existingUser != null)
        {
            return BadRequest("Email already exists");
        }

        var user = new User
        {
            Email = dto.Email,
            UserName = dto.Email,
            FirstName = dto.UserName,
            SecondName = dto.UserName,
            Role = "Candidate"
        };

        var result = await userManager.CreateAsync(user, dto.Password);
        if (!result.Succeeded)
        {
            var errors = result.Errors.Select(e => e.Description).ToList();
            return BadRequest(new { errors });
        }

        return Ok();
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(UserLoginDto dto)
    {
        var user = await userManager.FindByEmailAsync(dto.Email);
        if (user is null)
        {
            return Unauthorized("Invalid credentials");
        }

        var result = await signInManager.CheckPasswordSignInAsync(user, dto.Password, false);
        if (!result.Succeeded)
        {
            return Unauthorized("Invalid credentials");
        }

        var token = jwtService.GenerateToken(user);
        var refreshToken = jwtService.GenerateRefreshToken();

        user.RefreshToken = refreshToken;
        user.RefreshTokenExpiryTime = DateTime.UtcNow.AddDays(7);
        await userManager.UpdateAsync(user);

        return Ok(new { token, refreshToken });
    }
    
    [HttpPost("refresh-token")]
    public async Task<IActionResult> RefreshToken(TokenRequestDto tokenRequest)
    {
        var principal = jwtService.GetPrincipalFromExpiredToken(tokenRequest.Token);
        if (principal is null || principal.Identity is null || string.IsNullOrEmpty(principal.Identity.Name))
        {
            return BadRequest("Invalid access token or refresh token");
        }

        var userEmail = principal.Identity.Name;
        var user = await userManager.FindByEmailAsync(userEmail);
        if (user == null || user.RefreshToken != tokenRequest.RefreshToken || user.RefreshTokenExpiryTime <= DateTime.UtcNow)
        {
            return BadRequest("Invalid refresh token");
        }

        var newJwtToken = jwtService.GenerateToken(user);
        var newRefreshToken = jwtService.GenerateRefreshToken();

        user.RefreshToken = newRefreshToken;
        user.RefreshTokenExpiryTime = DateTime.UtcNow.AddDays(7);
        await userManager.UpdateAsync(user);

        return Ok(new { token = newJwtToken, refreshToken = newRefreshToken });
    }
    
    [Authorize]
    [HttpGet("me")]
    public async Task<IActionResult> GetCurrentUser()
    {
        var email = User.Identity?.Name;
        if (email is null)
        {
            return Unauthorized();
        }

        var user = await userManager.FindByEmailAsync(email);
        if (user is null)
        {
            return Unauthorized();
        }

        return Ok(new
        {
            user.Email,
            user.FirstName,
            user.SecondName,
            user.Role
        });
    }
}