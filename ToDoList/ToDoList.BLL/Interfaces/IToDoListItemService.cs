using ToDoList.Domain.DTO;

namespace ToDoList.BLL.Interfaces
{
    public interface IToDoListItemService
    {
        public Task<IEnumerable<GetToDoListItemDTO>> GetAllAsync();
        public Task<GetToDoListItemDTO> CreateToDoListItem(CreateToDoListItemDTO dto);

        public Task DeleteToDoListItemAsync(Guid id);

        public Task UpdateToDoListItemAsync(UpdateToDoListItemDTO dto);
    }
}
