using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class Homecontroller:Controller
    {
        [HttpGet]

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]

        public IActionResult Index(int startYear, int endYear)

        {
            return RedirectToAction("Result", new { startYear, endYear });
        }

        [HttpGet]

        public IActionResult Results(int startYear, int endYear)

        {
            return View(Personoftheyear.GetPersons(startYear, endYear));
        }
    }
}
