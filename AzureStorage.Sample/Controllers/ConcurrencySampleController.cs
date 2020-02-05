using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Concurrency.EFCORE;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AzureStorage.Sample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConcurrencySampleController : ControllerBase
    {
        public ConcurrencySampleController(IStudRepo studRepo)
        {
            StudRepo = studRepo;
        }

        public IStudRepo StudRepo { get; }

        [HttpPost("GetStudents")]
        public IActionResult GetStudents()
        {
            try
            {
                return Ok(StudRepo.GetStudents());
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [HttpPost("UpdateStudent")]
        public async Task<IActionResult> UpdateStudent([FromBody]Students students)
        {
            try
            {
                await StudRepo.UpdateStudent(students);
                return Ok();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                StringBuilder errors = NewMethod(ex);
                return BadRequest(errors);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        private static StringBuilder NewMethod(DbUpdateConcurrencyException ex)
        {
            StringBuilder errors = new StringBuilder();
            var exceptionEntry = ex.Entries.Single();
            var clientValues = (Students)exceptionEntry.Entity;
            var databaseEntry = exceptionEntry.GetDatabaseValues();

            if (databaseEntry == null) errors.Append("Unable to save changes. The department was deleted by another user.");
            else
            {

                var databaseValues = (Students)databaseEntry.ToObject();

                if (databaseValues.Name != clientValues.Name) errors.Append($"Current Db value for Name: {databaseValues.Name}");

                if (databaseValues.Address != clientValues.Address) errors.Append($"Current Db value for Address: {databaseValues.Name}");

                if (databaseValues.Age != clientValues.Age) errors.Append($"Current Db value for Age: {databaseValues.Age}");

            }

            return errors;
        }
    }
}