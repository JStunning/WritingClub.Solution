using System.Threading.Tasks;
using RestSharp;
using System.Collections.Generic;
using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace WritingClub.Models
{
  class ApiHelper
  {
    public static async Task<string> GetAll()
    {
      RestClient client = new RestClient("http://localhost:5000/api");
      RestRequest request = new RestRequest($"prompts", Method.GET);
      var response = await client.ExecuteTaskAsync(request);
      Console.WriteLine("Get All:", response.Content);
      return response.Content;
    }

    public static async Task<string> Get(int id)
    {
      RestClient client = new RestClient("http://localhost:5000/api");
      RestRequest request = new RestRequest($"prompts/{id}", Method.GET);
      var response = await client.ExecuteTaskAsync(request);
      Console.WriteLine("Get one:", response.Content);
      return response.Content;
    }

    public static async Task Post(string newPrompt) //newPrompt comes from Prompt Controller
    {
      Console.WriteLine("Post newPrompt:", newPrompt);
      RestClient client = new RestClient("http://localhost:5000/api");
      RestRequest request = new RestRequest($"prompts", Method.POST);
      request.AddHeader("Content-Type", "application/json");
      request.AddJsonBody(newPrompt);
      var response = await client.ExecuteTaskAsync(request);
      Console.WriteLine("Post:", response);
    }

    public static async Task Put(int id, string newPrompt)
    {
      RestClient client = new RestClient("http://localhost:5000/api");
      RestRequest request = new RestRequest($"prompts/{id}", Method.PUT);
      request.AddHeader("Content-Type", "application/json");
      request.AddJsonBody(newPrompt);
      var response = await client.ExecuteTaskAsync(request);
      Console.WriteLine("Put:", response);
    }
  }
}