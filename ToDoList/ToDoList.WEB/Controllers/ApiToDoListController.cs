using Microsoft.AspNetCore.Mvc;
using ToDoList.BLL.Interfaces;
using ToDoList.Domain.DTO;

namespace ToDoList.WEB.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ApiToDoListController : ControllerBase
    {
        private readonly ILogger<ToDoListController> _logger;
        private readonly IToDoListItemService _listItemService;
        public ApiToDoListController(ILogger<ToDoListController> logger, IToDoListItemService service)
        {
            _logger = logger;
            _listItemService = service;
        }

        [HttpPost]
        public async Task<IActionResult> Post(CreateToDoListItemDTO item, CancellationToken cancellationToken)
        {
            var result = await  _listItemService.CreateToDoListItemAsync(item, cancellationToken);

            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
        {
           await _listItemService.DeleteToDoListItemAsync(id, cancellationToken);

            return NoContent();
        }
        [HttpPut]
        public async Task<IActionResult> Update(UpdateToDoListItemDTO item, CancellationToken cancellationToken)
        {
            await _listItemService.UpdateToDoListItemAsync(item, cancellationToken);

            return Ok();
        }

    }
}
