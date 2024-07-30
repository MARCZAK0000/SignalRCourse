using Microsoft.AspNetCore.Identity;

namespace SignalRCourse.Database
{
    public class Account : IdentityUser
    {

        public virtual User User { get; set; }
    }
}
