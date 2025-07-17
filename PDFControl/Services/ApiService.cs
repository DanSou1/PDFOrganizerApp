using Microsoft.AspNetCore.Mvc;
using PDFControl.Models;
using System.Text.Json;
using static System.Net.WebRequestMethods;

namespace PDFControl.Services
{
    public class ApiService
    {
        private readonly HttpClient _httpClient;
        public ApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        [HttpGet]
        public async Task<List<DockeysModel>> GetKeys()
        {
            string url = "https://localhost:7214/api/Dockeys";
            var request = new HttpRequestMessage(HttpMethod.Get, url);
            var response = await _httpClient.SendAsync(request);
            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync();
            var responseDocKey = JsonSerializer.Deserialize<List<DockeysModel>>(json);
            return responseDocKey;
        }
    }
}
