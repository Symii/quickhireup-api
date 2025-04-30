namespace quickhireup_api.Application.DTOs;

public class JobAdDto
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime ExpirationDate { get; set; }
    public int CompanyId { get; set; }
    public List<int> SkillIds { get; set; }
}