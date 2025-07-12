using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Odoo_Hackathon_Project.Models;
using System.Net.Http;

namespace Odoo_Hackathon_Project.Controllers
{
    public class DashboardController : Controller
    {
        private readonly HttpClient _client;

        public DashboardController(IHttpClientFactory httpClientFactory)
        {
            _client = httpClientFactory.CreateClient();
            _client.BaseAddress = new Uri("https://localhost:7022/api/");
        }

        public async Task<IActionResult> Dashboard()
        {
            var response = await _client.GetAsync("Question");
            if (!response.IsSuccessStatusCode)
                return View(new List<Question>());

            var json = await response.Content.ReadAsStringAsync();
            var questions = JsonConvert.DeserializeObject<List<Question>>(json) ?? new List<Question>();

            // Inject mock vote/view/answer data
            var rnd = new Random();
            foreach (var q in questions)
            {
                q.Likes = rnd.Next(0, 100);
                q.Views = rnd.Next(100, 1000);
                q.AnswerCount = rnd.Next(0, 20);
                q.IsRead = rnd.Next(0, 2) == 1;
            }

            return View(questions);
        }
    }
}
