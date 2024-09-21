using StudentPortal.Web.Data;
using StudentPortal.Web.Models.Entities;

namespace StudentPortal.Web.Repositories.Interface
{
    public interface IStudentRepository
    {
        public Task<Student> CreateStudent(Student student);
        //public Task<Student> UpdateStudent(Student student);
        //public Task DeleteStudent(Student student);
        public Task<Student> GetAllStudents();
    }
}
