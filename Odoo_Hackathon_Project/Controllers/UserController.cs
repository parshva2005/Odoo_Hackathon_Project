﻿using Microsoft.AspNetCore.Mvc;

namespace Odoo_Hackathon_Project.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
