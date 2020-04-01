using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WritingClub.Models;
using WritingClub.Solution.Models;

namespace WritingClub.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            var allPrompts = Prompt.GetPrompts();
            return View(allPrompts);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
