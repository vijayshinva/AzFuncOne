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
    public static class NetworkInterface
    {
        [FunctionName("NetworkInterface")]
        public static IActionResult Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("NetworkInterface function processed a request.");

            return new OkObjectResult(System.Net.NetworkInformation.NetworkInterface.GetAllNetworkInterfaces().Select(ni => new { ni.Description, ni.NetworkInterfaceType, GetPhysicalAddress = ni.GetPhysicalAddress().ToString(), ni.SupportsMulticast, ni.OperationalStatus }));
        }
    }
}
