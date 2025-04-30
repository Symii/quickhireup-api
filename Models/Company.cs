namespace quickhireup_api.Models;

public class Company
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string Website { get; set; }
    public virtual ICollection<JobAd> JobAds { get; set; }
}