using Microsoft.AspNetCore.Mvc;

namespace Odoo_Hackathon_Project.Controllers
{
    public class NotificationController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
