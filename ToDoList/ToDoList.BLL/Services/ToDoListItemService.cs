using AutoMapper;
using Microsoft.EntityFrameworkCore;
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

        public async Task<GetToDoListItemDTO> CreateToDoListItemAsync(CreateToDoListItemDTO dto, CancellationToken cancellationToken)
        {
            var item = _mapper.Map<ToDoListItem>(dto);

            await _service.CreateToDoListItemAsync(item, cancellationToken);
            await _service.SaveChangeAsync(cancellationToken);

            return _mapper.Map<GetToDoListItemDTO>(item);
        }

        public async Task DeleteToDoListItemAsync(Guid id, CancellationToken cancellationToken)
        {
            var item = await _service.GetByIdAsync(id, cancellationToken);

            if (item == null)
            {
                return;
            }

            _service.DeleteToDoListItem(item);
            await _service.SaveChangeAsync(cancellationToken);

        }

        public async Task<IEnumerable<GetToDoListItemDTO>> GetAllAsync(CancellationToken cancellationToken)
        {
            var result = (await _service.GetAll().ToListAsync(cancellationToken)).OrderByDescending(t => t.Created);

            return _mapper.Map<IEnumerable<GetToDoListItemDTO>>(result);
        }

        public async Task UpdateToDoListItemAsync(UpdateToDoListItemDTO dto, CancellationToken cancellationToken)
        {
            var item = await _service.GetByIdAsync(dto.Id, cancellationToken);
            if (item == null)
            {
                return;
            }

            _mapper.Map(dto, item);

            _service.UpdateToDoListItem(item);
            await _service.SaveChangeAsync(cancellationToken);
        }
    }
}
