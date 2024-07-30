using SignalRCourse.Database;
using SignalRCourse.Model;

namespace SignalRCourse.Repository
{
    public interface IJobToDoRepository
    {
        Task<List<User>> GetAllUsers();

        Task<bool> CreateNotificationAsync(NotificationModelDto notification);

        Task<List<NotificationModelDto>> GetNotificationsAsync(string userID);

    }
}
