using Microsoft.AspNetCore.Mvc;

namespace MVCLab.Controllers
{
    public class StateController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }


        public IActionResult setsession()
        {
            HttpContext.Session.SetString("Name", "Reem");
            HttpContext.Session.SetInt32("Age", 22);


            return Content("data saved");
        }

        public IActionResult getsession()
        {
          string name=  HttpContext.Session.GetString("Name");
            int? age=  HttpContext.Session.GetInt32("Age");
            return Content($"the user name is {name} and her age is {age}");
        }
    }
}
