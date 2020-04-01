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
        [HttpPost]
        public IActionResult Index(Prompt prompt)
        {
          Prompt.Post(prompt);
          return RedirectToAction("Index");
        }
        public IActionResult Details(int id)
        {
          var thisPrompt = Prompt.GetDetails(id);
          return View(thisPrompt);
        }

        public IActionResult Edit(int id)
        {
          var editPrompt = Prompt.GetDetails(id);
          return View(editPrompt);
        }

        [HttpPost]
        public IActionResult Details(int id, Prompt prompt)
        {
          prompt.PromptId = id;
          Prompt.Put(prompt);
          return RedirectToAction("Details", id);
        }
    }
}