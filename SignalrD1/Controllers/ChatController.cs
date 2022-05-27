using Microsoft.AspNetCore.Mvc;
using SignalrD1.Models;

namespace SignalrD1.Controllers
{
    public class ChatController : Controller
    {
        signalrchatContext db;
        public ChatController(signalrchatContext db)
        {
            this.db = db;
        }
        public IActionResult Index()
        {
            return View(db.messages.ToList());
        }
    }
}
