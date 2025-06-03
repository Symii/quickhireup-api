using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using quickhireup_api.Application.DTOs;
using quickhireup_api.Data;
using quickhireup_api.Models;

namespace quickhireup_api.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class JobAdsController : ControllerBase
{
    private readonly AppDbContext _context;

    public JobAdsController(AppDbContext context)
    {
        _context = context;
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var jobAds = await _context.JobAds
            .Include(j => j.Company)
            .Include(j => j.JobAdSkills)
                .ThenInclude(jas => jas.Skill)
            .Select(j => new
            {
                j.Id,
                j.Title,
                j.Description,
                j.ExpirationDate,
                Company = j.Company.Name,
                Skills = j.JobAdSkills.Select(s => s.Skill.Name).ToList()
            })
            .ToListAsync();

        return Ok(jobAds);
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var jobAd = await _context.JobAds
            .Include(j => j.JobAdSkills)
            .FirstOrDefaultAsync(j => j.Id == id);

        if (jobAd == null)
            return NotFound();

        return Ok(jobAd);
    }
    
    [HttpPost]
    public async Task<IActionResult> Create(JobAdDto dto)
    {
        var jobAd = new JobAd
        {
            Title = dto.Title,
            Description = dto.Description,
            ExpirationDate = dto.ExpirationDate,
            CompanyId = dto.CompanyId,
            JobAdSkills = dto.SkillIds.Select(id => new JobAdSkill
            {
                SkillId = id
            }).ToList()
        };

        _context.JobAds.Add(jobAd);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetById), new { id = jobAd.Id }, jobAd);
    }
    
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, JobAdDto dto)
    {
        var jobAd = await _context.JobAds
            .Include(j => j.JobAdSkills)
            .FirstOrDefaultAsync(j => j.Id == id);

        if (jobAd == null)
            return NotFound();

        jobAd.Title = dto.Title;
        jobAd.Description = dto.Description;
        jobAd.ExpirationDate = dto.ExpirationDate;
        jobAd.CompanyId = dto.CompanyId;
        
        jobAd.JobAdSkills.Clear();
        foreach (var skillId in dto.SkillIds)
        {
            jobAd.JobAdSkills.Add(new JobAdSkill { SkillId = skillId });
        }

        await _context.SaveChangesAsync();
        return NoContent();
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var jobAd = await _context.JobAds.FindAsync(id);
        if (jobAd == null)
            return NotFound();

        _context.JobAds.Remove(jobAd);
        await _context.SaveChangesAsync();
        return NoContent();
    }
}