using System.Diagnostics;
using ToDoTask.Models;
using Microsoft.AspNetCore.Mvc;

namespace ToDoTask.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return RedirectToAction("Index", "ToDoTasks");
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return RedirectToAction("Index", "ToDoTasks");
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return RedirectToAction("Index", "ToDoTasks");
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
