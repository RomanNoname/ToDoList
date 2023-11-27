using ToDoList.Domain.Entites;

namespace ToDoList.DAL.Interfaces
{
    public interface IToDoListItemRepository
    {
        public Task<IEnumerable<ToDoListItem>> GetAllAsync();
        public Task<ToDoListItem?> GetByIdAsync(Guid id);
        public Task CreateToDoListItemAsync(ToDoListItem item);
        public void DeleteToDoListItem(ToDoListItem item);

        public void UpdateToDoListItem(ToDoListItem item);
        public Task SaveChangeAsync();
    }
}
