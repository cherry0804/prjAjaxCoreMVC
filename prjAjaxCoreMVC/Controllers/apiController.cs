using Microsoft.AspNetCore.Mvc;
using prjAjaxCoreMVC.ViewModel;

namespace prjAjaxCoreMVC.Controllers
{
    public class apiController : Controller
    {
        public IActionResult Index(string name,int age)
        {
            System.Threading.Thread.Sleep(5000);
            return Content($"Hello {name},age is {age}!!");
        }


        public IActionResult register(MemberViewModel member)
        {

            //return Content("<h2>Ajax 你好 !!</h2>","text/html", System.Text.Encoding.UTF8);
            return Content($"Hello {member.name}，{member.email},  You are {member.age} years old.");
        }
    }
}
