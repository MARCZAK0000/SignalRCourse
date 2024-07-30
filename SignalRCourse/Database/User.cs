namespace SignalRCourse.Database
{
    public class User
    {
        public string AccountID { get; set; }

        public string Email { get; set; }   

        public string Name { get; set; }   
        
        public string Surname { get; set; }

        public string PhoneNumber { get; set; }

        public virtual Account Account { get; set; }

        public virtual List<Notification> Notifications { get; set; }
    }
}
