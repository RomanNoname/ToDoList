using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using ToDoList.BLL.Interfaces;
using ToDoList.WEB.Models;

namespace ToDoList.WEB.Controllers
{
    public class ToDoListController : Controller
    {
        private readonly ILogger<ToDoListController> _logger;
        private readonly IToDoListItemService _listItemService;
        public ToDoListController(ILogger<ToDoListController> logger, IToDoListItemService service)
        {
            _logger = logger;
            _listItemService = service;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _listItemService.GetAllAsync());
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
