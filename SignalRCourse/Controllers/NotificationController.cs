using Microsoft.AspNetCore.Mvc;
using SignalRCourse.Model;
using SignalRCourse.Repository;

namespace SignalRCourse.Controllers
{
    [ApiController]
    [Route("api/notification")]
    public class NotificationController : ControllerBase
    {
        private readonly IJobToDoRepository _jobToDoRepository;

        public NotificationController(IJobToDoRepository jobToDoRepository)
        {
            _jobToDoRepository = jobToDoRepository;
        }


        [HttpPost]
        public async Task<IActionResult> CreateNotification(NotificationModelDto notification)
        {
            var result = await _jobToDoRepository.CreateNotificationAsync(notification);

            return Ok(result);  
        }
    }
}
