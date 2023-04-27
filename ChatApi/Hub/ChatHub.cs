using Microsoft.AspNetCore.SignalR;

namespace ChatApi.Hub
{
    public class ChatHub : Hub<IChatHub>
    {

        public async Task SendMessage(string message, int fromUserId, int toUserId)
        {
            await Clients.All.SendMessage(message, fromUserId, toUserId);
        }

    }
}
