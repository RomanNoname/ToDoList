using Microsoft.EntityFrameworkCore;
using ToDoList.DAL.Interfaces;
using ToDoList.Domain.Entites;

namespace ToDoList.DAL.Repositories
{
    public class ToDoListItemRepository : IToDoListItemRepository
    {
        private readonly ApplicationDbContext _context;

        public ToDoListItemRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task CreateToDoListItemAsync(ToDoListItem item, CancellationToken cancellationToken = default)
        {
            await _context.ToDoListItems.AddAsync(item, cancellationToken);
        }

        public void DeleteToDoListItem(ToDoListItem item)
        {
            _context.ToDoListItems.Remove(item);
        }

        public IQueryable<ToDoListItem> GetAll()
        {
            return _context.ToDoListItems.AsQueryable();
        }

        public async Task<ToDoListItem?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return await _context.ToDoListItems.FirstOrDefaultAsync(t => t.Id == id, cancellationToken);
        }

        public async Task SaveChangeAsync(CancellationToken cancellationToken = default)
        {
            await _context.SaveChangesAsync(cancellationToken);
        }

        public void UpdateToDoListItem(ToDoListItem item)
        {
            _context.ToDoListItems.Update(item);
        }
    }
}
