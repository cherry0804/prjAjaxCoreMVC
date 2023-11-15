using Microsoft.AspNetCore.Mvc;
using prjAjaxCoreMVC.ViewModel;

namespace prjAjaxCoreMVC.Controllers
{
    public class apiController : Controller
    {

        private readonly IWebHostEnvironment _host;
        public apiController(IWebHostEnvironment host)
        {
            _host = host;
        }

        public IActionResult Index(string name,int age)
        {
            System.Threading.Thread.Sleep(5000);
            return Content($"Hello {name},age is {age}!!");
        }


        public IActionResult register(MemberViewModel member,IFormFile formFile)
        {
            string path = Path.Combine(_host.WebRootPath, "uploads", formFile.FileName);

            using (var fileStream = new FileStream(path,FileMode.Create))
            {
                formFile.CopyTo(fileStream);
            }


            return Content(path);

            //return Content("<h2>Ajax 你好 !!</h2>","text/html", System.Text.Encoding.UTF8);
            //return Content($"Hello {member.name}，{member.email},  You are {member.age} years old.");
        }
    }
}
