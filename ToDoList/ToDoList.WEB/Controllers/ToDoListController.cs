using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using ToDoList.WEB.Models;

namespace ToDoList.WEB.Controllers
{
    public class ToDoListController : Controller
    {
        private readonly ILogger<ToDoListController> _logger;

        public ToDoListController(ILogger<ToDoListController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
               

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
