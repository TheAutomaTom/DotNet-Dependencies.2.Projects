using System.Threading.Tasks;
using ClassLibrary;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;

namespace FunctionApp
{
  public static class Function1
  {
    [FunctionName("how-many-times-must-one-look-up-before-they-can-see-the-sky")]
    public static async Task<IActionResult> Run([HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = null)] HttpRequest req, ILogger log)
    {
      log.LogInformation("C# HTTP trigger function processed a request.");


      string responseMessage = DeepThinker.TheAnswer;

      return new OkObjectResult(responseMessage);
    }
  }
}
