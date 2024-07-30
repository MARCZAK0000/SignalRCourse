using Microsoft.AspNetCore.SignalR;
using SignalRCourse.Repository;

namespace SignalRCourse.Hubs
{
    public class NotificationHub:Hub
    {

        private readonly IJobToDoRepository _jobToDoRepository;

        public NotificationHub(IJobToDoRepository jobToDoRepository)
        {
            _jobToDoRepository = jobToDoRepository;
        }

        public async Task CreateNotification(string userID)
        {
            await Clients.Users(userID).SendAsync("SendNotification", await _jobToDoRepository.GetNotificationsAsync(userID));
        }

        public async Task GetNotifications()
        {
            await Clients.Caller.SendAsync("InitNotification", await _jobToDoRepository.GetNotificationsAsync(Context.UserIdentifier!));
        }
    }
}
