using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace AzFuncOne
{
    public static class Environment
    {
        [FunctionName("Environment")]
        public static IActionResult Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("Environment function processed a request.");

            var environment = new
            {
                System.Environment.MachineName,
                System.Environment.CommandLine,
                System.Environment.Is64BitOperatingSystem,
                System.Environment.Is64BitProcess,
                System.Environment.OSVersion.Platform,
                System.Environment.OSVersion.VersionString,
                System.Environment.CurrentDirectory,
                System.Environment.SystemDirectory,
                System.Environment.ProcessorCount,
                System.Environment.WorkingSet,
                System.Environment.UserDomainName,
                System.Environment.UserName
            };

            return new OkObjectResult(environment);
        }
    }
}
