namespace quickhireup_api.Application.Interfaces
{
    /// <summary>
    /// Interfejs dla serwisu generującego opisy stanowisk pracy.
    /// </summary>
    public interface IJobDescriptionService
    {
        /// <summary>
        /// Asynchronicznie generuje opis stanowiska pracy na podstawie podanej nazwy stanowiska i lokalizacji.
        /// </summary>
        /// <param name="position">Nazwa stanowiska (np. "Frontend Developer").</param>
        /// <param name="location">Lokalizacja stanowiska (np. "Warszawa").</param>
        /// <returns>Wygenerowany opis stanowiska jako ciąg znaków.</returns>
        Task<string> GenerateJobDescriptionAsync(string position, string location);
    }
}