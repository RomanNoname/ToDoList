using ToDoList.Domain.DTO;

namespace ToDoList.BLL.Interfaces
{
    public interface IToDoListItemService
    {
        public Task<IEnumerable<GetToDoListItemDTO>> GetAllAsync(CancellationToken cancellationToken);
        public Task<GetToDoListItemDTO> CreateToDoListItemAsync(CreateToDoListItemDTO dto, CancellationToken cancellationToken);

        public Task DeleteToDoListItemAsync(Guid id,CancellationToken cancellationToken);

        public Task UpdateToDoListItemAsync(UpdateToDoListItemDTO dto, CancellationToken cancellationToken);
    }
}
