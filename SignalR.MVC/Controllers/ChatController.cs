using Microsoft.AspNetCore.Mvc;

namespace SignalR.MVC.Controllers
{
    public class ChatController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
