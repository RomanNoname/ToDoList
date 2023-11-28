using ToDoList.Domain.Entites;

namespace ToDoList.DAL.Interfaces
{
    public interface IToDoListItemRepository
    {
        public IQueryable<ToDoListItem> GetAll();
        public Task<ToDoListItem?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
        public Task CreateToDoListItemAsync(ToDoListItem item, CancellationToken cancellationToken);
        public void DeleteToDoListItem(ToDoListItem item);

        public void UpdateToDoListItem(ToDoListItem item);
        public Task SaveChangeAsync(CancellationToken cancellationToken);
    }
}
