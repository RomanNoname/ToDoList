using AutoMapper;
using ToDoList.Domain.DTO;
using ToDoList.Domain.Entites;

namespace ToDoList.WEB.Mapping
{
    public class ToDoListItemProfile : Profile
    {
        public ToDoListItemProfile()
        {
            CreateMap<ToDoListItem, GetToDoListItemDTO>();
            CreateMap<CreateToDoListItemDTO, ToDoListItem>();
            CreateMap<UpdateToDoListItemDTO, ToDoListItem>();
        }
    }
}
