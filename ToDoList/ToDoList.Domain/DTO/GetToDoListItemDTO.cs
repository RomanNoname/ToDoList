using System.Text.Json;
using System.Text.Json.Nodes;

namespace ToDoList.Domain.DTO
{
    public record class GetToDoListItemDTO(Guid Id, string Title, bool IsFinished, DateTime Created, DateTime Updated)
    {
        public override string ToString()
        {
            return JsonSerializer.Serialize(this);
        }
    };
}
