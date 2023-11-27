using System.ComponentModel.DataAnnotations;

namespace ToDoList.Domain.DTO
{
    public class CreateToDoListItemDTO
    {
        [MaxLength(200)]
        public string Title {  get; set; }
    }
}
