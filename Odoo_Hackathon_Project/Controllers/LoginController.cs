using Microsoft.AspNetCore.Mvc;
using Odoo_Hackathon_Project.Models;
using System.Text;
using System.Text.Json;

namespace Odoo_Hackathon_Project.Controllers
{
    public class LoginController : Controller
    {
        private readonly HttpClient _client;

        public LoginController(IHttpClientFactory httpClientFactory)
        {
            _client = httpClientFactory.CreateClient();
            _client.BaseAddress = new Uri("https://localhost:7022/api/");
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(User loginUser)
        {
            var json = JsonSerializer.Serialize(loginUser);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _client.PostAsync("User/login", content); // Assuming your API has this

            if (response.IsSuccessStatusCode)
            {
                // Example: Set session data
                HttpContext.Session.SetString("Username", loginUser.Username);
                return RedirectToAction("Dashboard", "Dashboard");
            }

            ViewBag.Error = "Invalid username or password.";
            return View();
        }
    }
}
