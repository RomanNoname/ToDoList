using AutoMapper;
using ToDoList.BLL.Interfaces;
using ToDoList.DAL.Interfaces;
using ToDoList.Domain.DTO;
using ToDoList.Domain.Entites;

namespace ToDoList.BLL.Services
{
    public class ToDoListItemService : IToDoListItemService
    {
        private readonly IToDoListItemRepository _service;
        private readonly IMapper _mapper;
        public ToDoListItemService(IToDoListItemRepository service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        public async Task<GetToDoListItemDTO> CreateToDoListItem(CreateToDoListItemDTO dto)
        {
            var item = _mapper.Map<ToDoListItem>(dto);

            await _service.CreateToDoListItemAsync(item);
            await _service.SaveChangeAsync();

            return _mapper.Map<GetToDoListItemDTO>(item);
        }

        public async Task DeleteToDoListItemAsync(Guid id)
        {
            var item = await _service.GetByIdAsync(id);

            if (item == null)
            {
                return;
            }

            _service.DeleteToDoListItem(item);
            await _service.SaveChangeAsync();

        }

        public async Task<IEnumerable<GetToDoListItemDTO>> GetAllAsync()
        {
            var result = (await _service.GetAllAsync()).OrderByDescending(t => t.Created);

            return _mapper.Map<IEnumerable<GetToDoListItemDTO>>(result);
        }

        public async Task UpdateToDoListItemAsync(UpdateToDoListItemDTO dto)
        {
            var item = await _service.GetByIdAsync(dto.Id);
            if (item == null)
            {
                return;
            }

            _mapper.Map(dto, item);

            _service.UpdateToDoListItem(item);
            await _service.SaveChangeAsync();
        }
    }
}
