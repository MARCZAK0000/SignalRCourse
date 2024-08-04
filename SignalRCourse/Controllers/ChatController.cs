using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace SignalRCourse.Controllers
{
    public class ChatController:Controller
    {
        [Authorize]
        public IActionResult Index() 
        {
            return View();
        }
    }
}
