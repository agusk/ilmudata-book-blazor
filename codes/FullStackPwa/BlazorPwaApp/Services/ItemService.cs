using System.Net.Http.Json;

namespace BlazorPwaApp.Services
{
    public class ItemService
    {
        private readonly HttpClient _httpClient;

        public ItemService(IHttpClientFactory HttpClientFactory)
        {
            _httpClient = HttpClientFactory.CreateClient("ExternalApi");
        }

        public async Task<List<string>?> GetItemsAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<string>>("api/items");
        }

        public async Task AddItemAsync(string item)
        {
            await _httpClient.PostAsJsonAsync("api/items", item);
        }
    }
}
