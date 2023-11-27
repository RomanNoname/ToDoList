using System.ComponentModel.DataAnnotations;

namespace ToDoList.Domain.DTO
{
    public record class UpdateToDoListItemDTO(
        Guid Id,
        [MaxLength(200)]
        [Required]
        string Title,
        bool IsFinished,
        DateTime Created);
}
