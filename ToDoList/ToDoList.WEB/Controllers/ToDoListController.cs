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

        [ResponseCache(Duration = 30, Location = ResponseCacheLocation.Client, NoStore = false)]
        public async Task<IActionResult> Index(CancellationToken cancellationToken)
        {
            return View(await _listItemService.GetAllAsync(cancellationToken));
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [ResponseCache(Duration = 240, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult SomeTrouble()
        {
            return View();
        }
    }
}
