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
    private AppDbContext _ctx;

    public JobAdsController(AppDbContext ctx)
    {
        _ctx = ctx;
    }
        
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var jobAds = await _ctx.JobAds
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
        var jobAd = await _ctx.JobAds
            .Include(j => j.JobAdSkills)
            .FirstOrDefaultAsync(j => j.Id == id);

        if (jobAd is null)
        {
            return NotFound();
        }

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

        _ctx.JobAds.Add(jobAd);
        await _ctx.SaveChangesAsync();

        return CreatedAtAction(nameof(GetById), new { id = jobAd.Id }, jobAd);
    }
    
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, JobAdDto dto)
    {
        var jobAd = await _ctx.JobAds
            .Include(j => j.JobAdSkills)
            .FirstOrDefaultAsync(j => j.Id == id);

        if (jobAd is null)
        {
            return NotFound();
        }

        jobAd.Title = dto.Title;
        jobAd.Description = dto.Description;
        jobAd.ExpirationDate = dto.ExpirationDate;
        jobAd.CompanyId = dto.CompanyId;
        
        jobAd.JobAdSkills.Clear();
        foreach (var skillId in dto.SkillIds)
        {
            jobAd.JobAdSkills.Add(new JobAdSkill { SkillId = skillId });
        }

        await _ctx.SaveChangesAsync();
        return NoContent();
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var jobAd = await _ctx.JobAds.FindAsync(id);
        if (jobAd is null)
        {
            return NotFound();
        }

        _ctx.JobAds.Remove(jobAd);
        await _ctx.SaveChangesAsync();
        return NoContent();
    }
}