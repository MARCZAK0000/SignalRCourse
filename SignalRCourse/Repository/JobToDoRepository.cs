using Microsoft.EntityFrameworkCore;
using SignalRCourse.Database;
using SignalRCourse.Model;

namespace SignalRCourse.Repository
{
    public class JobToDoRepository : IJobToDoRepository
    {
        private readonly DatabaseContext _context;

        public JobToDoRepository(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<List<NotificationModelDto>> GetNotificationsAsync (string userID)
        {
            var notification = await _context
                .Notifications
                .Where(pr=>pr.AccountId == userID)  
                .Select(pr => new NotificationModelDto
                {
                    Name = pr.NotificationTitle,
                    Description = pr.NotificationContent,
                    AccountID = pr.AccountId
                })
                .ToListAsync();
                
            return notification;
        }

        public async Task<bool> CreateNotificationAsync(NotificationModelDto notification)
        {
            var notificationNew = new Notification
            {
                AccountId = notification.AccountID,
                NotificationTitle = notification.Name,
                NotificationContent = notification.Description
            };

            await _context.AddAsync(notificationNew);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<List<User>> GetAllUsers()
        {
            return await _context.Users.ToListAsync();
        }
    }
}
