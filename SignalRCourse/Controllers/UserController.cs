using Microsoft.AspNetCore.Mvc;
using SignalRCourse.Repository;

namespace SignalRCourse.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController:ControllerBase
    {
        private readonly IJobToDoRepository _jobToDoRepository;

        public UserController(IJobToDoRepository jobToDoRepository)
        {
            _jobToDoRepository = jobToDoRepository;
        }

        [HttpGet("users")]
        public async Task<IActionResult> GetAllUsers()
        {
            var result = await _jobToDoRepository.GetAllUsers(); 

            return Ok(result);  
        }
    }
}
