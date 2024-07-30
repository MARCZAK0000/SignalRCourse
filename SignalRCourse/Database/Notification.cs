namespace SignalRCourse.Database
{
    public class Notification
    {
        public int NotificationID { get; set; }

        public string NotificationTitle { get; set; }   

        public string NotificationContent { get; set; }

        public virtual User User { get; set; }

        public string AccountId { get; set; }  
    }
}
