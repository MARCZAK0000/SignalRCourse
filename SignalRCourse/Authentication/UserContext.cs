using Azure.Core;
using System.Security.Claims;

namespace SignalRCourse.Authentication
{
    public class UserContext : IUserContext
    {
        private readonly IHttpContextAccessor _httpContext;
        public UserContext(IHttpContextAccessor httpContext) 
        {
            _httpContext = httpContext;
        }

        public CurrentUser GetCurrentUser()
        {
            var user = _httpContext.HttpContext!.User;
            if (user == null || !user.Identity!.IsAuthenticated) 
            {
                throw new Exception("Not authorized");
            }
            var userName = user.FindFirst(c => c.Type == ClaimTypes.Name)!.Value;
            var email = user.FindFirst(c => c.Type == ClaimTypes.Email)!.Value;
            if(userName == null || email == null)
            {
                throw new Exception("Something went wrong");
            }
            return new CurrentUser(userName, email);
        }
    }
}
