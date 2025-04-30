namespace quickhireup_api.Models;

public class Skill
{
    public int Id { get; set; }
    public string Name { get; set; }
    
    public virtual ICollection<JobTemplate> Templates { get; set; }
    public List<JobAdSkill> JobAdSkills { get; set; }
}