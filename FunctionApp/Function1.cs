using System.Threading.Tasks;
using ClassLibrary;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;

namespace FunctionApp
{
  public class Function1
  {
    [FunctionName("what-is-six-times-seven")]
    public async Task<IActionResult> Run([HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = null)] HttpRequest req, ILogger log)
    {
      log.LogInformation("C# HTTP trigger function processed a request.");

      string responseMessage = QuestionResolver.Answer;

      return new OkObjectResult($"What is six times seven? \nThe answer is {responseMessage}.");
    }
  }
}
