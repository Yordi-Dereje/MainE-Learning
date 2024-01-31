using E_LearningWebApp.Areas.Identity.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using E_LearningWebApp.Models;
using E_LearningWebApp.Repository;

namespace E_LearningWebApp.Controllers
{
    //[Authorize(Policy = "Adminroles")]
    public class AdminController : Controller
    {
        private E_LearningDbContext _context = new E_LearningDbContext();

        private readonly UserManager<E_LearningWebAppUser> _userManager;
        public AdminController(UserManager<E_LearningWebAppUser> userManager)
        {
            _userManager = userManager;
        }

        public IActionResult DashBoard() { return View(); }

        public IActionResult Index()
        {
            ViewBag.userid = _userManager.GetUserId(HttpContext.User);
            return View();
        }
        public IActionResult CreateCourse(Courses course)
        {
            CourseRepository cr = new CourseRepository(_context);

            if (!ModelState.IsValid)
                return View("Create");

            cr.AddCourse(course);
            return RedirectToAction("Index");
        }


        [HttpGet("GetAllCourses")]
        public IActionResult GetAllCourses()
        {
            CourseRepository pr = new CourseRepository(_context);
            List<Courses> courses = pr.GetAllCourses();
            return View(courses);
        }

        public IActionResult GetCourseById(int id)
        {
            CourseRepository pr = new CourseRepository(_context);
            Courses course = pr.GetCourseById(id);
            return View(course);
        }
        [HttpGet]
        public async Task<IActionResult> EditCourse(int courseid)
        {
            /*CourseRepository pr = new CourseRepository(_context);
            Courses course = pr.GetCourseById(CourseId);*/
            var course = await _context.Courses.FindAsync(courseid);
            return View(course);
        }


        [HttpPost]
        public async Task<IActionResult> EditCourse(Courses UpdatedCourse)
        {
            Courses course = await _context.Courses.FindAsync(UpdatedCourse.CourseId);

            if (course is not null)
            {
                course.CourseName = UpdatedCourse.CourseName;
                course.CourseCode = UpdatedCourse.CourseCode;
                course.CoursePrice = UpdatedCourse.CoursePrice;
                course.CourseDescription = UpdatedCourse.CourseDescription;
                course.CoursePrice = UpdatedCourse.CoursePrice;
                course.CourseDuration = UpdatedCourse.CourseDuration;
                await _context.SaveChangesAsync();
            }
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult DeleteCourse(int? CourseId)
        {
            var courses = _context.Courses.Find(CourseId);
            return View(courses);
        }
        [HttpPost]
        public IActionResult DeleteCourse(int? CourseId, Courses courses)
        {
            var cour = _context.Courses.Find(CourseId);
            _context.Courses.Remove(cour);
            _context.SaveChanges();
            /*CourseRepository cr = new CourseRepository(_context);
            Courses course = cr.GetCourseById(CourseId);
            cr.DeleteCourse(course);*/
            return RedirectToAction("Index");
        }
    }
}
