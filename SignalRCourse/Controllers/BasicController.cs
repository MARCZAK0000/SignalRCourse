using Microsoft.AspNetCore.Mvc;
using SignalRCourse.Models;

namespace SignalRCourse.Controllers
{
    public class BasicController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(BasicControllerModel basic)
        {
            return View(basic);
        }

        public IActionResult Informations()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> GetInformations()
        {
            
            return Ok(new BasicControllerModel
            {
                Email = "jan.marczak98@gmail.com",
                Name = "Jakub",
                Surname = "Marczak"
            });
        } 
    }
}
