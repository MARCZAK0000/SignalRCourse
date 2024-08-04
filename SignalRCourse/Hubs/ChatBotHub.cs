using Microsoft.AspNetCore.SignalR;
using System.Security.Claims;

namespace SignalRCourse.Hubs
{
    public class ChatBotHub:Hub
    {
        public static readonly List<string> ChatUser = new();

        public override async Task OnConnectedAsync()
        {
            var currentUser = Context.User;
            ChatUser.Add(currentUser.FindFirst(c => c.Type == ClaimTypes.NameIdentifier).Value);
            await Clients.All.SendAsync("connectToChat", ChatUser);
        }

        public override Task OnDisconnectedAsync(Exception? exception)
        {
            var currentUser = Context.User;
            ChatUser.Remove(currentUser.FindFirst(c=>c.Type == ClaimTypes.NameIdentifier).Value);
            return base.OnDisconnectedAsync(exception);
        }

        public async Task GetConnectedUsers()
        {
            await Clients.Caller.SendAsync("connectedUsers", ChatUser);
        }

    }
}
