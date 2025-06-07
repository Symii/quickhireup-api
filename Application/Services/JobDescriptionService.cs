using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using quickhireup_api.Models.Request;

namespace quickhireup_api.Application.Services
{
    public class JobDescriptionService(IHttpClientFactory httpClientFactory) : IJobDescriptionService
    {
        private readonly HttpClient _httpClient = httpClientFactory.CreateClient();

        public async Task<string> GenerateJobDescriptionAsync(JobDescriptionRequest jobDescriptionRequest)
        {
            var prompt = $"Napisz profesjonalne ogłoszenie o pracę w języku polskim dla stanowiska {jobDescriptionRequest.JobTitle} " +
                         $"w lokalizacji {jobDescriptionRequest.Location}. " +
                         $"Rodzaj zatrudnienia: {jobDescriptionRequest.EmploymentType}. " +
                         $"Rodzaj umowy: {jobDescriptionRequest.ContractType}. " +
                         $"Doświadczenie zawodowe: {jobDescriptionRequest.Experience}. " +
                         $"Uwzględnij obowiązki, wymagania i benefity.";
            
            var requestBody = new
            {
                model = "mistral",
                prompt = prompt,
                stream = false
            };

            var json = JsonSerializer.Serialize(requestBody);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync("http://localhost:11434/api/generate", content);
            var responseContent = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                throw new ApplicationException($"Ollama API error: {responseContent}");
            }

            var result = JsonSerializer.Deserialize<OllamaResponse>(responseContent, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            return result?.Response ?? "Brak odpowiedzi.";
        }

        private class OllamaResponse
        {
            [JsonPropertyName("response")]
            public string Response { get; set; }
        }
    }
}