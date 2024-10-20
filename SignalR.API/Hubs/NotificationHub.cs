using Microsoft.AspNetCore.SignalR;

namespace SignalR.API.Hubs
{
    public class NotificationHub: Hub
    {
        private readonly ILogger<NotificationHub> _logger;

        public NotificationHub(ILogger<NotificationHub> logger)
        {
            _logger = logger;
        }

        public async Task SendNotification(string message)
        {
            await Clients.All.SendAsync("ReceiveNotification",message);
            _logger.LogInformation(message);
        }
    }
}
