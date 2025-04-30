namespace quickhireup_api.Models;

public class CV
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public string FilePath { get; set; }
    public DateTime SubmittedAt { get; set; } = DateTime.Now;
    public bool UserConsent { get; set; }
    public string RetentionStatus { get; set; }

    public virtual User User { get; set; }
}