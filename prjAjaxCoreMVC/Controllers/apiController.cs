using Microsoft.AspNetCore.Mvc;

namespace prjAjaxCoreMVC.Controllers
{
    public class apiController : Controller
    {
        public IActionResult Index(string name,int age)
        {
            System.Threading.Thread.Sleep(5000);
            return Content($"Hello {name},age is {age}!!");
        }
    }
}
