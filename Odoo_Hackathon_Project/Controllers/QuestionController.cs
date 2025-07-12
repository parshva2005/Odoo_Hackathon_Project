using System.Text;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Odoo_Hackathon_Project.Models;

public class QuestionController : Controller
{
    private readonly HttpClient _client;

    public QuestionController(IHttpClientFactory httpClientFactory)
    {
        _client = httpClientFactory.CreateClient();
        _client.BaseAddress = new Uri("https://localhost:7022/api/");
    }

    [HttpPost]
    public async Task<IActionResult> AskQuestion(Question question)
    {
        question.CreatedAt = DateTime.Now;

        var json = JsonSerializer.Serialize(question);
        var content = new StringContent(json, Encoding.UTF8, "application/json");

        var response = await _client.PostAsync("Question", content);

        if (response.IsSuccessStatusCode)
        {
            return RedirectToAction("Dashboard", "Dashboard");
        }
        else
        {
            ModelState.AddModelError("", "Something went wrong. Try again.");
            return View();
        }
    }
}
