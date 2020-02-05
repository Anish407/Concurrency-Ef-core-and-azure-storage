using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;

namespace TableStorage.CRUD.Controllers
{
    [Route("BlobStorage")]
    public class BlobStorageController : Controller
    {
        public BlobStorageController(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        [HttpPost("CreateContainer")]
        public async Task<IActionResult> CreateContainer()
        {
            string constring = this.Configuration["connection"];
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(constring);

            var blobClient = storageAccount.CreateCloudBlobClient();

            var container = blobClient.GetContainerReference("Images");
            await container.CreateIfNotExistsAsync();

            return Ok();
        }
    }
}