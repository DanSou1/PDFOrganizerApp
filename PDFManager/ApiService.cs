using Newtonsoft.Json;
using PDFProcessor.Models;
using System.Net.Http.Headers;

public class ApiService
{
    private readonly HttpClient _client;
    private readonly string _baseUrl = "https://localhost:7214/api";

    public ApiService()
    {
        _client = new HttpClient();
        _client.DefaultRequestHeaders.Accept.Clear();
        _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
    }

    public async Task<List<Dockey>> GetDockeysAsync()
    {
        var response = await _client.GetAsync($"{_baseUrl}/Dockeys");
        response.EnsureSuccessStatusCode();
        var json = await response.Content.ReadAsStringAsync();
        return JsonConvert.DeserializeObject<List<Dockey>>(json);
    }

    public async Task<bool> SendLogAsync(Logprocess log)
    {
        var jsonContent = new StringContent(JsonConvert.SerializeObject(log), System.Text.Encoding.UTF8, "application/json");
        var response = await _client.PostAsync($"{_baseUrl}/Logprocesses", jsonContent);
        return response.IsSuccessStatusCode;
    }
}
