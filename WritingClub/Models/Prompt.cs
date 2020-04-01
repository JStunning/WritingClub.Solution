using System.Collections.Generic;
using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace WritingClub.Models
{
  public class Prompt
  {
    public int PromptId { get; set; }
    public string PromptName { get; set; }
    public string AuthorName { get; set; }
    // public int Journal { get; set; }

    public static List<Prompt> GetPrompts()
    {
      var apiCallTask = ApiHelper.GetAll();
      var result = apiCallTask.Result;

      JArray jsonResponse = JsonConvert.DeserializeObject<JArray>(result);
      List<Prompt> PromptList = JsonConvert.DeserializeObject<List<Prompt>>(jsonResponse.ToString());

      return PromptList;
    }
  }
}