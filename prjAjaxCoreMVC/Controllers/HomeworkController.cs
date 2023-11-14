using Microsoft.AspNetCore.Mvc;

namespace prjAjaxCoreMVC.Controllers
{
    public class HomeworkController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Homework1()
        {
            return View();
        }
    }
}
