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

        public async Task CreateToDoListItemAsync(ToDoListItem item)
        {
            await _context.ToDoListItems.AddAsync(item);
        }

        public void DeleteToDoListItem(ToDoListItem item)
        {
            _context.ToDoListItems.Remove(item);
        }

        public async Task<IEnumerable<ToDoListItem>> GetAllAsync()
        {
            return await _context.ToDoListItems.ToListAsync();
        }

        public async Task<ToDoListItem?> GetByIdAsync(Guid id)
        {
            return await _context.ToDoListItems.FirstOrDefaultAsync(t => t.Id == id);
        }

        public async Task SaveChangeAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void UpdateToDoListItem(ToDoListItem item)
        {
            _context.ToDoListItems.Update(item);
        }
    }
}
