using ToDoClient.Models;

namespace ToDoClient.Services
{
    public class ToDoService : IToDoService
    {
        private readonly HttpClient _httpClient;

        public ToDoService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<ToDoItem>> GetAllAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<ToDoItem>>("api/todos");
        }

        public async Task<ToDoItem> GetByIdAsync(int id)
        {
            return await _httpClient.GetFromJsonAsync<ToDoItem>($"api/todos/{id}");
        }

        public async Task AddAsync(ToDoItem item)
        {
            await _httpClient.PostAsJsonAsync("api/todos", item);
        }

        public async Task UpdateAsync(ToDoItem item)
        {
            await _httpClient.PutAsJsonAsync($"api/todos/{item.Id}", item);
        }

        public async Task DeleteAsync(int id)
        {
            await _httpClient.DeleteAsync($"api/todos/{id}");
        }
    }

}
