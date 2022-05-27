using Microsoft.AspNetCore.Mvc;
using SignalrD1.Models;

namespace SignalrD1.Controllers
{
    public class UserController : Controller
    {
        signalrchatContext db;
        public UserController(signalrchatContext db)
        {
            this.db = db;
        }

        public IActionResult Index()
        {
            return View(db.users.ToList());
        }

        // HTTP GET VERSION
        public IActionResult Create()
        {            
            return View();
        }
        // HTTP POST VERSION  
        [HttpPost]
        public IActionResult Create(User user)
        {
            db.users.Add(user);
            return RedirectToAction("Index");
        }
    }
}
