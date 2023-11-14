using Microsoft.AspNetCore.Mvc;

namespace prjAjaxCoreMVC.Controllers
{
    public class apiController : Controller
    {
        public IActionResult Index()
        {
            return Content("Hello Ajax!!");
        }
    }
}
