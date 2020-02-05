using System.Collections.Generic;
using System.Threading.Tasks;

namespace Concurrency.EFCORE
{
    public interface IStudRepo
    {
        IEnumerable<Students> GetStudents();

        Task UpdateStudent(Students students);
    }
}