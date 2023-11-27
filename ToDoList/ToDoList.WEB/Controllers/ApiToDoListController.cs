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
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Post(CreateToDoListItemDTO item)
        {
            var result = await  _listItemService.CreateToDoListItem(item);

            return Ok(result);
        }

        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Delete(Guid id)
        {
           await _listItemService.DeleteToDoListItemAsync(id);

            return NoContent();
        }
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Update(UpdateToDoListItemDTO item)
        {
            await _listItemService.UpdateToDoListItemAsync(item);

            return Ok();
        }

    }
}
