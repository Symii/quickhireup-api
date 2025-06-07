using quickhireup_api.Models.Request;

namespace quickhireup_api.Application.Services
{
    /// <summary>
    /// Interfejs dla serwisu generującego opisy stanowisk pracy.
    /// </summary>
    public interface IJobDescriptionService
    {
        /// <summary>
        /// Asynchronicznie generuje opis stanowiska pracy na podstawie danych zawartych w żądaniu.
        /// </summary>
        /// <param name="jobDescriptionRequest">
        /// Obiekt zawierający szczegóły stanowiska do wygenerowania opisu
        /// </param>
        /// <returns>Wygenerowany opis stanowiska jako ciąg znaków.</returns>
        Task<string> GenerateJobDescriptionAsync(JobDescriptionRequest jobDescriptionRequest);
    }
}