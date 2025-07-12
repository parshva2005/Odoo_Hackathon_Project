using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Odoo_Hackathon_Project.Controllers
{
    public class AnswerController : Controller
    {
        private readonly HttpClient _httpClient;

        public AnswerController()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri("https://localhost:7022/"); // Change this to your API base URL
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<IActionResult> AnswerPage()
        {
            List<AnswerModel> answers = new List<AnswerModel>();

            HttpResponseMessage response = await _httpClient.GetAsync("api/Answers"); // your API endpoint

            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                answers = JsonConvert.DeserializeObject<List<AnswerModel>>(jsonData);
            }

            return View(answers); // Pass to View
        }
    }

    public class AnswerModel
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public int QuestionId { get; set; }
        public int UserId { get; set; }
        // Add other properties as needed
    }
}
