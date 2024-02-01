using E_LearningWebApp.Areas.Identity.Data;
using E_LearningWebApp.Models;
using E_LearningWebApp.Repository;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace E_LearningWebApp.Controllers
{
    public class SubCourseController : Controller
    {
        private E_LearningDbContext _context = new E_LearningDbContext();

        /*private readonly UserManager<E_LearningWebAppUser> _userManager;*/
        public SubCourseController()
        {
        }
        public IActionResult CreateSubCourse()
        {
            return View();
        }
        [HttpGet("GetCourseById")]
        public IActionResult GetCourseById([FromRoute] int courseid)
        {
            CourseRepository pr = new CourseRepository(_context);
            Courses course = pr.GetCourseById(courseid);
            ViewBag.CourseId = course.CourseId;
            return View(course.CourseId);
        }

        [HttpGet]
        public IActionResult CreateSubCourse(int courseid)
        {
            CourseRepository pr = new CourseRepository(_context);
            Courses course = pr.GetCourseById(courseid);
            ViewBag.CourseId = course.CourseId;
            ViewBag.CourseName = course.CourseName;
            return View();
        }

        [HttpPost]
        public IActionResult CreateSubCourse(int courseId, SubCourses subcourse)
        {

            SubCourseRepository scr = new SubCourseRepository(_context);
            subcourse.CourseId = courseId;
            //if (!ModelState.IsValid)
            //    return View("CreateSubCourse");
            scr.AddSubCourse(subcourse);
            return RedirectToAction("CreateSubCourse", new { courseid  = courseId });
        }
    }
}
