using System.ComponentModel.DataAnnotations;

namespace ToDoList.Domain.DTO
{
    public class CreateToDoListItemDTO
    {
        [MaxLength(100)]
        [Required]
        public string Title {  get; set; }
    }
}
