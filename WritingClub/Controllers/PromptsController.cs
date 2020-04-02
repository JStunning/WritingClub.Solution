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
          Console.WriteLine("Get Working");
          return View(allPrompts);
        }
        [HttpPost]
        public IActionResult Index(Prompt prompt) //Prompt Post is getting
        {
          Console.WriteLine("\n PromptController prompt \n \n \n" + prompt.Title);
          Prompt.Post(prompt);
          Console.WriteLine("Post Working");
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
          Console.WriteLine("Put Working");
          return View(editPrompt);
        }

        [HttpPost]
        public IActionResult Details(int id, Prompt prompt)
        {
          prompt.PromptId = id;
          Prompt.Put(prompt);
          Console.WriteLine("Put Working");
          return RedirectToAction("Details", id);
        }
    }
}