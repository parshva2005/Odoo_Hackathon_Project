using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Odoo_Hackathon_Project.Models;
using Odoo_Hackathon_Project.Models.Odoo_Hackathon_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Odoo_Hackathon_Project.Controllers
{
    public class DashboardController : Controller
    {
        private readonly HttpClient _client;

        public DashboardController(IHttpClientFactory httpClientFactory)
        {
            _client = httpClientFactory.CreateClient();
            _client.BaseAddress = new Uri("https://localhost:7022/api/"); // your real API base
        }

        [HttpGet("dashboard")]
        public async Task<ActionResult<IEnumerable<DashboardQuestionDTO>>> GetDashboardQuestions()
        {
            var questions = await _context.Questions
                .Include(q => q.Answers)
                    .ThenInclude(a => a.Votes)
                .ToListAsync();

            var result = questions.Select(q => new DashboardQuestionDTO
            {
                Id = q.Id,
                Title = q.Title,
                Content = q.Content,
                CreatedAt = q.CreatedAt,
                AnswerCount = q.Answers.Count,
                VoteCount = q.Answers.Sum(a => a.Votes.Count(v => v.IsUpvote) - a.Votes.Count(v => !v.IsUpvote)),
                Views = new Random().Next(100, 1000) // Optional mocked views
            }).ToList();

            return Ok(result);
        }

    }
}
