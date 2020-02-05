using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Concurrency.EFCORE
{
    // No 
    public class StudRepo : IStudRepo
    {
        public StudRepo(SampleDbContext context) => (Context) = context;

        public SampleDbContext Context { get; }


        public IEnumerable<Students> GetStudents()
        {
            return Context.Student.ToList();
        }

        public async Task UpdateStudent(Students students)
        {

            var existingStudent = await Context.Student.FirstOrDefaultAsync(i => i.Id == students.Id);

            existingStudent.Address = students.Address;
            existingStudent.Name = students.Name;
            existingStudent.Age = students.Age;
            
            Context.Entry(existingStudent).State = EntityState.Modified;

            await Context.SaveChangesAsync();

        }
    }
}
