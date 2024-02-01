using Microsoft.AspNetCore.Mvc;
using E_LearningWebApp.Models;
using E_LearningWebApp.Repository;
using E_LearningWebApp.Data;
using Microsoft.AspNetCore.Identity;
using E_LearningWebApp.Areas.Identity.Data;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using Microsoft.EntityFrameworkCore;

namespace E_LearningWebApp.Controllers
{
    public class CourseController : Controller
    {
        private E_LearningDbContext _context = new E_LearningDbContext();

        private readonly UserManager<E_LearningWebAppUser> _userManager;
        public CourseController(UserManager<E_LearningWebAppUser> _userManager)
        {
            this._userManager = _userManager;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult CreateCourse()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateCourse(Courses course)
        {
            CourseRepository cr = new CourseRepository(_context);

            if (!ModelState.IsValid)
                return View("CreateCourse");

            cr.AddCourse(course);
            return RedirectToAction("GetAllCourses");
        }


        [HttpGet("GetAllCourses")]
        public IActionResult GetAllCourses()
        {
            CourseRepository pr = new CourseRepository(_context);
            List<Courses> courses = pr.GetAllCourses();
            return View(courses);
        }
        [HttpGet]
        public async Task<IActionResult> GetCourseById([FromQuery] int courseid)
        {
            var course = await _context.Courses.FindAsync(courseid);
            return View(course);

        }
        [HttpGet("editCourses/{courseid}")]
        public async Task<IActionResult> EditCourses( int courseid)
        {
            var course = await _context.Courses.FindAsync(courseid);
            return View(course);
        }
     


        [HttpPost("editCourses/{courseid}")]
        public IActionResult EditCourses(int courseid, Courses UpdatedCourse)
        {
            var courses = _context.Courses.AsNoTracking().FirstOrDefaultAsync(course => course.CourseId ==courseid);

            if (courses != null)
            {
                _context.Update(UpdatedCourse);
                _context.SaveChanges();
            }

            return RedirectToAction("GetAllCourses", "Course");
        }

        [HttpGet("deleteCourse/{courseid}")]
        public async Task<IActionResult> DeleteCourse(int courseid)
        {
            var course = await _context.Courses.FindAsync(courseid);
            return View(course);
        }
        /*all above are working i dare you to touch it and die*/
        [HttpPost("deleteCourse/{courseid}")]
        public IActionResult DeleteCourse(int courseid, Courses deletedcourse)
        {
            var courses =_context.Courses.AsNoTracking().FirstOrDefaultAsync(course => course.CourseId == courseid);

            if (courses != null)
            {
                _context.Remove(deletedcourse);
                _context.SaveChanges();
            }

            return RedirectToAction("GetAllCourses", "Course");
        }
    }
                
    } 

