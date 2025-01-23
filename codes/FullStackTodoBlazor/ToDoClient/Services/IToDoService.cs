using ToDoClient.Models;

namespace ToDoClient.Services
{
    public interface IToDoService
    {
        Task<List<ToDoItem>> GetAllAsync();
        Task<ToDoItem> GetByIdAsync(int id);
        Task AddAsync(ToDoItem item);
        Task UpdateAsync(ToDoItem item);
        Task DeleteAsync(int id);
    }
}
