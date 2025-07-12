using Microsoft.AspNetCore.Mvc;

namespace Odoo_Hackathon_Project.Controllers
{
    public class QuestionController : Controller
    {
        public IActionResult AskQuestion()
        {
            return View();
        }
    }
}
