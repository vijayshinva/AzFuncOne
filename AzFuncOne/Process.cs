using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Diagnostics;

namespace AzFuncOne
{
    public static class Process
    {
        [FunctionName("Process")]
        public static IActionResult Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("Process function processed a request.");

            var currentProcess = System.Diagnostics.Process.GetCurrentProcess();
            var process = new { currentProcess.Id, currentProcess.ProcessName, currentProcess.MachineName, currentProcess.StartTime };

            return new OkObjectResult(process);
        }
    }
}
