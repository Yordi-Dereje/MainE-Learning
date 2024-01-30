using Microsoft.AspNetCore.Mvc;
using E_LearningWebApp.Models;
using E_LearningWebApp.Repository;
using E_LearningWebApp.Data;
using Microsoft.AspNetCore.Identity;
using E_LearningWebApp.Areas.Identity.Data;

namespace E_LearningWebApp.Controllers
{
    public class CourseController : Controller
    {
        private E_LearningDbContext _context = new E_LearningDbContext();

        private readonly UserManager<E_LearningWebAppUser> _userManager;
        public CourseController(/*E_LearningDbContext _context*/ UserManager<E_LearningWebAppUser> _userManager)
        {
          /*  this._context = _context;*/
            this._userManager = _userManager;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Courses course)
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

        /*
                [HttpPost]
                public ActionResult Edit(Customer customer)
                {
                    _context.Customers.Update(customer);
                    _context.SaveChanges();
                    return RedirectToAction("Index");
                }*/

        /*[HttpGet("Edit/{CourseId}")]*/
        public ActionResult Edit(int CourseId)
        {
            CourseRepository pr = new CourseRepository(_context);
            Courses course = pr.GetCourseById(CourseId);
            return View(course);
        }

        /* [HttpPost("Edit/{CourseId}")]
         [ValidateAntiForgeryToken]

         public IActionResult Edit(int CourseId, Courses UpdatedCourse)
         {
             CourseRepository cr = new CourseRepository(_context);
             Courses course = cr.GetCourseById(CourseId);
             if (course is not null)
             {
                 course.CourseName = UpdatedCourse.CourseName;
                 course.CourseCode = UpdatedCourse.CourseCode;
                 course.CoursePrice = UpdatedCourse.CoursePrice;
                 course.CourseDescription = UpdatedCourse.CourseDescription;
                 course.CoursePrice = UpdatedCourse.CoursePrice;
                 course.CourseDuration = UpdatedCourse.CourseDuration;
                 cr.UpdateCourse(course);
             }
             return RedirectToAction("Index");
         }*/
        [HttpPost]
        public IActionResult Edit(Courses UpdatedCourse)
        {
            CourseRepository cr = new CourseRepository(_context);

            cr.UpdateCourse(UpdatedCourse);

            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Delete(int? CourseId)
        {
            var courses = _context.Courses.Find(CourseId);
            return View(courses);
        }
        [HttpPost]
        public IActionResult Delete(int? CourseId, Courses courses)
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
