using System.Text.Json.Serialization;

namespace quickhireup_api.Models;

public class JobAdSkill
{
    public int JobAdId { get; set; }
    [JsonIgnore]
    public JobAd JobAd { get; set; }

    public int SkillId { get; set; }
    [JsonIgnore]
    public Skill Skill { get; set; }
}