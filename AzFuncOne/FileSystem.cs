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
    public static class FileSystem
    {
        [FunctionName("FileSystem")]
        public static IActionResult Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("FileSystem function processed a request.");

            string name = req.Query["folder"];
            name ??= Directory.GetCurrentDirectory();
            if (Directory.Exists(name))
            {
                var folder = new DirectoryInfo(name);
                return new OkObjectResult(folder.GetFileSystemInfos().Select(fi => new { fi.FullName, fi.Attributes }));
            }
            return new NotFoundObjectResult(name);
        }
    }
}
