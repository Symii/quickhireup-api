using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using quickhireup_api.Application.Interfaces;

namespace quickhireup_api.Application.Services
{
    public class JobDescriptionService : IJobDescriptionService
    {
        private readonly HttpClient _httpClient;

        public JobDescriptionService(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient();
        }

        public async Task<string> GenerateJobDescriptionAsync(string position, string location)
        {
            var prompt = $"Napisz profesjonalne ogłoszenie o pracę w języku polskim dla stanowiska {{position}} w lokalizacji {{location}}. Uwzględnij wymagania, obowiązki i benefity.";

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