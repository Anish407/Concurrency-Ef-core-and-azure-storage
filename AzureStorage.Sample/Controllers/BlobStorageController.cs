using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AzureStorage.Blob;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AzureStorage.Sample.Controllers
{
    [Route("api/BlobStorage")]
    [ApiController]
    public class BlobStorageController : ControllerBase
    {
        public BlobStorageController(ITodoRepo blobRepo)
        {
            BlobRepo = blobRepo;
        }

        public ITodoRepo BlobRepo { get; }

        [HttpPost("Create/{name}")]
        public IActionResult CreateNewContainer(string name)
        {
            this.BlobRepo.CreateNewBlobContainer(name);

            return Ok();
        }
    }
}