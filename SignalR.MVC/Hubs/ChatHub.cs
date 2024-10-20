using Microsoft.AspNetCore.SignalR;
using SignalR.MVC.Context;
using SignalR.MVC.Models;

namespace SignalR.MVC.Hubs
{
    public class ChatHub : Hub
    {
        private readonly ChatDbContext _chatDbContext;
        private readonly ILogger<ChatHub> _logger;

        public ChatHub(ChatDbContext chatDbContext, ILogger<ChatHub> logger)
        {
            _chatDbContext = chatDbContext;
            _logger = logger;
        }

        public async Task Send(string userName, string message)
        {
            await Clients.All.SendAsync("ReciveMessage",userName, message);

            var msg = new Message
            {
                Msg = message,
                UserName = userName,

            };

            _chatDbContext.Messages.Add(msg);
            await _chatDbContext.SaveChangesAsync();

        }

        public async Task JoinGroup(string groupName, string userName)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, groupName);
            await Clients.OthersInGroup(groupName).SendAsync("NewMemberJoin", userName, groupName);

            _logger.LogInformation(Context.ConnectionId);
        }
        public async Task SendToGroup(string groupName, string sender, string message)
        {
            await Clients.OthersInGroup(groupName).SendAsync("ReciveMessageFromGroup", sender, message);
            var msg = new Message
            {
                Msg = message,
                UserName = sender,

            };

            _chatDbContext.Messages.Add(msg);
            await _chatDbContext.SaveChangesAsync();
        }

    }
}
