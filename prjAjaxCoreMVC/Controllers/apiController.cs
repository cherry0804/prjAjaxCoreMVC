using Microsoft.AspNetCore.Mvc;

namespace prjAjaxCoreMVC.Controllers
{
    public class apiController : Controller
    {
        public IActionResult Index(string name,int age)
        {
            return Content($"Hello {name},age is {age}!!");
        }
    }
}
