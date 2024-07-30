namespace SignalRCourse.Authentication
{
    public class CurrentUser
    {
        public CurrentUser(string userId, string email)
        {
            UserId = userId;
            Email = email;
        }

        public string UserId { get; set; }

        public string Email { get; set; }       

    }
}
