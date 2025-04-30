namespace quickhireup_api.Application.Interfaces;

public interface IJobDescriptionService
{
    Task<string> GenerateJobDescriptionAsync(string position, string location);
}