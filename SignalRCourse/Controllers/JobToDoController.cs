using Azure.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SignalRCourse.Model;
using SignalRCourse.Repository;

namespace SignalRCourse.Controllers
{
   
    public class JobToDoController : Controller
    {
        private readonly IJobToDoRepository _jobToDoRepository;

        public JobToDoController(IJobToDoRepository jobToDoRepository)
        {
            _jobToDoRepository = jobToDoRepository;
        }

        public IActionResult Index()
        {
            return View();
        }    
    }
}