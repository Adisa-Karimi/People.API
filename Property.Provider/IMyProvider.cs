using People.Domain.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace People.Provider
{
    public interface IMyProvider
    {
        Task<IEnumerable<StudentDto>> GetAllStudents();
        StudentDto AddStudent(StudentDto student);
    }
}
