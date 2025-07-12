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
                return View(new List<DashboardQuestionDTO>());

            var json = await response.Content.ReadAsStringAsync();
            var questions = JsonConvert.DeserializeObject<List<Question>>(json) ?? new List<Question>();

            // Map manually
            var result = questions.Select(q => new DashboardQuestionDTO
            {
                Id = q.Id,
                Title = q.Title ?? "",
                Content = q.Content,
                CreatedAt = q.CreatedAt,
                VoteCount = q.Likes,
                AnswerCount = q.AnswerCount,
                Views = q.Views
            }).ToList();

            return View(result);
        }

    }
}
