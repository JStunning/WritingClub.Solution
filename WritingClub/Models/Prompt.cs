using System.Collections.Generic;
using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace WritingClub.Models
{
  public class Prompt
  {
    public int PromptId { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
    public string AuthorName { get; set; }
    // public int Journal { get; set; }

    public static List<Prompt> GetPrompts()
    {
      var apiCallTask = ApiHelper.GetAll();
      var result = apiCallTask.Result;

      JArray jsonResponse = JsonConvert.DeserializeObject<JArray>(result);
      List<Prompt> promptList = JsonConvert.DeserializeObject<List<Prompt>>(jsonResponse.ToString());

      return promptList;
    }

    public static Prompt GetDetails(int id)
    {
      var apiCallTask = ApiHelper.Get(id);
      var result = apiCallTask.Result;

      JObject jsonResponse = JsonConvert.DeserializeObject<JObject>(result);
      Prompt prompt = JsonConvert.DeserializeObject<Prompt>(jsonResponse.ToString());

      return prompt;
    }

    public static void Post(Prompt prompt)
    {
      string jsonPrompt = JsonConvert.SerializeObject(prompt);
      Console.WriteLine("\n\n\n JSONPrompt \n\n\n" + jsonPrompt);
      var apiCallTask = ApiHelper.Post(jsonPrompt);
    }

    public static void Put(Prompt prompt)
    {
      string jsonPrompt = JsonConvert.SerializeObject(prompt);
      var apiCallTask = ApiHelper.Put(prompt.PromptId, jsonPrompt);
    }

  }
}