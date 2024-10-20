using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using SignalR.API.Hubs;

namespace SignalR.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class NotificationController : ControllerBase
    {
        private readonly IHubContext<NotificationHub> _hubContext;

        public NotificationController(IHubContext<NotificationHub> hubContext)
        {
            _hubContext = hubContext;
        }

        [HttpGet]
        public async Task<IActionResult> SendNotify(string message)
        {
            //TODO: Invoke Hub Send Notifiction Method

            await _hubContext.Clients.All.SendAsync("ReceiveNotification", message);

            return Ok(message);

            
        }
    }
}
