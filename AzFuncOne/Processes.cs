using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Linq;

namespace AzFunctionInternals
{
    public static class Processes
    {
        [FunctionName("Processes")]
        public static IActionResult Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("Processes function processed a request.");

            return new OkObjectResult(System.Diagnostics.Process.GetProcesses().Select(p => new { p.ProcessName, p.Id, p.SessionId }));
        }
    }
}
