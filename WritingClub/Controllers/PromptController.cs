using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using WritingClub.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace WritingClub.Controllers
{
    public class PromptsController : Controller
    {
        public IActionResult Index()
        {
          var allPrompts = Prompt.GetPrompts();
          return View(allPrompts);
        }
    }
}