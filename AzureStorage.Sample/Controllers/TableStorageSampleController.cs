using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AzureStorage.TableStorage;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AzureStorage.Sample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TableStorageSampleController : ControllerBase
    {
        public TableStorageSampleController(ITableStorageRepo tableStorageRepo)
        {
            TableStorageRepo = tableStorageRepo;
        }

        public ITableStorageRepo TableStorageRepo { get; }

        [HttpPost("CreateTable")]
        public IActionResult CreateTable([FromBody]string tableName)
        {
            try
            {
               return Ok(this.TableStorageRepo.GetDataEntities());
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }
    }
}