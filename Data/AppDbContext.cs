namespace quickhireup_api.Data;

using Microsoft.EntityFrameworkCore;
using Models;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options) { }

    public DbSet<JobAd> JobAds { get; set; }
    public DbSet<Company> Companies { get; set; }
    public DbSet<Skill> Skills { get; set; }
    public DbSet<JobTemplate> JobTemplates { get; set; }
    public DbSet<CV> CVs { get; set; }
    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        modelBuilder.Entity<JobAdSkill>()
            .HasKey(j => new { j.JobAdId, j.SkillId });

        modelBuilder.Entity<JobAdSkill>()
            .HasOne(j => j.JobAd)
            .WithMany(j => j.JobAdSkills)
            .HasForeignKey(j => j.JobAdId);

        modelBuilder.Entity<JobAdSkill>()
            .HasOne(s => s.Skill)
            .WithMany(s => s.JobAdSkills)
            .HasForeignKey(s => s.SkillId);
    }
}