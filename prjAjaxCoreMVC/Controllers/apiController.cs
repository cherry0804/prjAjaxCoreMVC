using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using prjAjaxCoreMVC.Models;
using prjAjaxCoreMVC.ViewModel;

namespace prjAjaxCoreMVC.Controllers
{
    public class apiController : Controller
    {

        private readonly IWebHostEnvironment _host;
        private readonly DemoContext _demoContext;

        public apiController(IWebHostEnvironment host,DemoContext demoContext)
        {
            _host = host;
            _demoContext = demoContext;
        }

        public IActionResult Index(string name,int age)
        {
            System.Threading.Thread.Sleep(5000);
            return Content($"Hello {name},age is {age}!!");
        }


        public IActionResult register(Members member,IFormFile formFile)
        {
            string path = Path.Combine(_host.WebRootPath, "uploads", formFile.FileName);

            using (var fileStream = new FileStream(path,FileMode.Create))
            {
                formFile.CopyTo(fileStream);
            }

            member.FileName = formFile.FileName;
            //將上傳的圖轉成二進位
            byte[]? imgByte = null;
            using (var memoryStream = new MemoryStream())
            {
                formFile.CopyTo(memoryStream);
                imgByte = memoryStream.ToArray();
            }
            member.FileData = imgByte;

            //將資料寫進資料庫中
            _demoContext.Members.Add(member);
            _demoContext.SaveChanges();

            return Content("新增成功");

            //return Content(path);

            //return Content("<h2>Ajax 你好 !!</h2>","text/html", System.Text.Encoding.UTF8);
            //return Content($"Hello {member.name}，{member.email},  You are {member.age} years old.");
        }

        public IActionResult Cities()
        {
            var cities = (from c in _demoContext.Address
                         select c.City).Distinct();

            return Json(cities);
        }

        public IActionResult districts(string city)
        {
            var districts = (from d in _demoContext.Address
                             where d.City == city
                             select d.SiteId).Distinct();

            return Json(districts);
        }

        public IActionResult Roads(string city,string district)
        {
            var roads = (from d in _demoContext.Address
                        where d.City == city && d.SiteId == city + district
                        select d.Road).Distinct();

            return Json(roads);
        }

        public IActionResult GetImageByte(int id = 1)
        {
            Members? member = _demoContext.Members.Find(id);
            byte[]? img = member?.FileData;

            if (img != null)
            {
                return File(img, "image/jpeg");
            }
            return NotFound();
        }


        public IActionResult checkName(MemberViewModel vm)
        {
            var q = _demoContext.Members.Where(m => m.Name == vm.name).Select(m => m.Name).ToList();


            if (!(q.Count==0))
            {
                return Content("該姓名已被使用"); 
            }
            else if (vm.name == null)
            {
                return Content("請輸入姓名");
            }
            else
            {
                return Content("該姓名可使用");
            }

        }

        public IActionResult checkEmail(MemberViewModel vm)
        {
            var q = _demoContext.Members.Where(m => m.Email == vm.email).Select(m => m.Email).ToList();


            if (!(q.Count==0))
            {
                return Content("該信箱已被使用");
            }
            else if (vm.email == null)
            {
                return Content("請輸入信箱");
            }
            else
            {
                return Content("該信箱可使用");
            }

        }
    }
}
