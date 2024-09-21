using StudentPortal.Web.Data;
using StudentPortal.Web.Models.Entities;
using StudentPortal.Web.Repositories.Interface;

namespace StudentPortal.Web.Repositories.Implementation
{
    public class StudentRepository : IStudentRepository
    {
        private readonly ApplicationDBContext dBContext;

        public StudentRepository(ApplicationDBContext dBContext)
        {
            this.dBContext = dBContext;
        }
        public async Task<Student> CreateStudent(Student student)
        {
            await dBContext.Students.AddAsync(student);
            await dBContext.SaveChangesAsync();

            return student;
        }
        public async Task<Student> DeleteStudent(Student student)
        {
            dBContext.Students.Remove(student);
            await dBContext.SaveChangesAsync();

            return student;
        }

        public async Task<Student> GetAllStudents()
        {
            throw new NotImplementedException();
        }

        public async Task<Student> UpdateStudent(Student student)
        {
            throw new NotImplementedException();
        }
    }
}
