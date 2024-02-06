using E_LearningWebApp.Areas.Identity.Data;
using E_LearningWebApp.Models;
using E_LearningWebApp.Repository;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace E_LearningWebApp.Controllers
{
    public class SubCourseController : Controller
    {
        private E_LearningDbContext _context = new E_LearningDbContext();
        //private readonly object webHostEnvironment;

        public SubCourseController()/*IWebHostEnvironment webHostEnvironment*/
        {
            //this.webHostEnvironment = webHostEnvironment;
        }

        /* ...works perfectly dont touch [HttpGet("GetAllSubCourses")]
         public IActionResult GetAllSubCourses()
         {
             SubCourseRepository scr = new SubCourseRepository(_context);
             List<SubCourses> subcourses = scr.GetAllSubCourse();
             return View(subcourses);
         }*/

       

        [HttpGet("GetAllSubCourses/{courseid}")]
        public IActionResult GetAllSubCourses(int courseid)
        {
            SubCourseRepository scr = new SubCourseRepository(_context);
            List<SubCourses> subcourses = scr.GetAllSubCourse(courseid);
            ViewBag.CourseId = courseid;
            return View(subcourses); 
        }
        public IActionResult CreateSubCourse()
        {
            return View();
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
            scr.AddSubCourse(subcourse);
            return RedirectToAction("CreateSubCourse", new { courseid  = courseId
    });
        }


[HttpGet]
        public async Task<IActionResult> GetSubCourseById([FromQuery] int subcourseid)
        {
            var subcourse = await _context.SubCourses.FindAsync(subcourseid);
            ViewBag.CourseId = subcourseid;
            return View(subcourse);

        }
        [HttpGet("editSubCourse/{courseid}/{subcourseid}")]
        public async Task<IActionResult> EditSubCourse(int courseid,int subcourseid)
        {
            CourseRepository pr = new CourseRepository(_context);
            Courses course = pr.GetCourseById(courseid);
            ViewBag.CourseId = course.CourseId;
            ViewBag.CourseName = course.CourseName;
            var subcourse = await _context.SubCourses.FindAsync(subcourseid);
            return View(subcourse);
        }
        [HttpPost("editSubCourse/{courseid}/{subcourseid}")]
        public IActionResult EditSubCourseAsync(int courseid,int subcourseid, SubCourses UpdatedSubCourse)
        {
             var subcourses = _context.SubCourses.AsNoTracking().FirstOrDefaultAsync(subcourse => subcourse.SubCourseId == subcourseid);
             if (subcourses != null)
            {
                _context.Update(UpdatedSubCourse);
            }
            return RedirectToAction("GetAllSubCourses", "SubCourse", new { courseid = courseid });
        }

        [HttpGet("deleteSubCourse/{courseid}/{subcourseid}")]
        public async Task<IActionResult> DeleteSubCourse(int courseid,int subcourseid)
        {
            CourseRepository pr = new CourseRepository(_context);
            Courses course = pr.GetCourseById(courseid);
            ViewBag.CourseId = course.CourseId;
            ViewBag.CourseName = course.CourseName;
            var subcourse = await _context.SubCourses.FindAsync(subcourseid);
            return View(subcourse);
        }

        [HttpPost("deleteSubCourse/{courseid}/{subcourseid}")]
        public IActionResult DeleteSubCourse(int courseid, SubCourses deletedcourse, int subcourseid)
        {
            var subcourses = _context.SubCourses.AsNoTracking().FirstOrDefaultAsync(course => course.SubCourseId == subcourseid);

            if (subcourses != null)
            {
                _context.Remove(deletedcourse);
                _context.SaveChanges();
            }

            return RedirectToAction("GetAllSubCourses", "SubCourse", new { courseid = courseid });
        }

    }
}
