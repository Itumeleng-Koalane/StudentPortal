using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentPortal.Web.Data;
using StudentPortal.Web.Models;
using StudentPortal.Web.Models.DTO;
using StudentPortal.Web.Models.Entities;
using StudentPortal.Web.Repositories.Interface;

namespace StudentPortal.Web.Controllers
{
    public class StudentsController : Controller
    {
        private readonly IStudentRepository studentRepository;
        private readonly ApplicationDBContext dBContext;

        public StudentsController(IStudentRepository studentRepository, ApplicationDBContext dBContext)
        {
            this.studentRepository = studentRepository;
            this.dBContext = dBContext;
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(CreateStudentRequestDto requestDto)
        {
            var student = new Student()
            {
                Name = requestDto.Name,
                Email = requestDto.Email,
                PhoneNumber = requestDto.PhoneNumber,
                Subscribed = requestDto.Subscribed
            };

            await studentRepository.CreateStudent(student);

            var response = new Student()
            {
                Name = student.Name,
                Email = student.Email,
                PhoneNumber = student.PhoneNumber,
                Subscribed = student.Subscribed
            };

            TempData["message"] = "Student Details Saved Successfully!!!";

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> List()
        {
            var student = dBContext.Students.ToList();

            return View(student);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var student = await dBContext.Students.FindAsync(id);

            return View(student);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Student studentViewModel)
        {
            var student = await dBContext.Students.FindAsync(studentViewModel.Id);

            if (student is not null)
            {
                student.Name = studentViewModel.Name;
                student.Email = studentViewModel.Email;
                student.PhoneNumber = studentViewModel.PhoneNumber;
                student.Subscribed = studentViewModel.Subscribed;

                await dBContext.SaveChangesAsync();
            }
            TempData["message"] = "Student Details Updated Successfully!!!";

            return RedirectToAction("List", "Students");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Student studentViewModel)
        {
            var student = await dBContext.Students
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == studentViewModel.Id);

            if (student is not null)
            {
                dBContext.Students.Remove(studentViewModel);
                await dBContext.SaveChangesAsync();
            }
            TempData["message"] = "Student Deleted Successfully!!!";

            return RedirectToAction("List", "Students");
        }
    }
}
