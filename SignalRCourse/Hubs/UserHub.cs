using Microsoft.AspNetCore.SignalR;

namespace SignalRCourse.Hubs
{
    public class UserHub : Hub
    {
        public static int TotalViews { get; set; } = 0;

        public static int CurrentUser { get; set; } = 0;

        public override Task OnConnectedAsync()
        {
            CurrentUser++;
            Clients.All.SendAsync("updateCurrentUser", CurrentUser).GetAwaiter().GetResult();
            return base.OnConnectedAsync();
        }

        public override Task OnDisconnectedAsync(Exception? exception)
        {
            CurrentUser--;
            Clients.All.SendAsync("updateCurrentUser", CurrentUser).GetAwaiter().GetResult();
            return base.OnDisconnectedAsync(exception);
        }
        public async Task JoinPage()
        {
            TotalViews++;
            await Clients.All.SendAsync("updateTotalView", TotalViews);
        }
    }
}
