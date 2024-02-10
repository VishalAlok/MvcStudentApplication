using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MvsStudentApplication.Data;
using MvsStudentApplication.Models;
using MvsStudentApplication.Models.Entities;
using System.Security.Cryptography.Xml;

namespace MvsStudentApplication.Controllers
{
    public class StudentsController : Controller
    {
        private readonly ApplicationDbContext _dbContext;
        public StudentsController(ApplicationDbContext dbContext)
        {
            this._dbContext = dbContext;
        }


        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddStudentViewModel viewModel)
        {
            var Student = new Student
            {
                Name = viewModel.Name,
                Email = viewModel.Email,
                IsActive = viewModel.IsActive,
                Phone = viewModel.Phone
            };
            await _dbContext.Students.AddAsync(Student);
            await _dbContext.SaveChangesAsync();

            //return View();
            return RedirectToAction("List", "Students");
        }


        [HttpGet]
        public async Task<IActionResult> List()
        {
            var students = await _dbContext.Students.ToListAsync();

            return View(students);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var students = await _dbContext.Students.FindAsync(id);

            return View(students);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Student viewModel)
        {
            var students = await _dbContext.Students.FindAsync(viewModel.Id);

            if (students is not null)
            {
                students.Name = viewModel.Name;
                students.Email = viewModel.Email;
                students.IsActive = viewModel.IsActive;
                students.Phone = viewModel.Phone;
            }
            await _dbContext.SaveChangesAsync();

            return RedirectToAction("List","Students");
        }

        [HttpGet]
        public async Task<IActionResult> Delete(Guid id)
        {
            var students = await _dbContext.Students.FindAsync(id);

            if (students is not null)
            {
                _dbContext.Students.Remove(students);
                await _dbContext.SaveChangesAsync();
            }
            return RedirectToAction("List", "Students");
        }
    }
}
