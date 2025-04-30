using System.Text.Json.Serialization;
using quickhireup_api.Models.Enums;

namespace quickhireup_api.Models;

public class JobAd
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime PostedAt { get; set; } = DateTime.Now;
    public DateTime ExpirationDate { get; set; }
    public EmploymentType EmploymentType { get; set; }
    public ExperienceLevel ExperienceLevel { get; set; }
    public string Location { get; set; }
    public WorkplaceType WorkplaceType { get; set; }
    public decimal? Salary { get; set; }
    public string Currency { get; set; }
    public SalaryPeriod? SalaryPeriod { get; set; }
    public string Industry { get; set; }
    public string JobBenefits { get; set; }
    public string ApplicationInstructions { get; set; }

    public int CompanyId { get; set; }
    [JsonIgnore]
    public virtual Company Company { get; set; }
    
    public List<JobAdSkill> JobAdSkills { get; set; }
}