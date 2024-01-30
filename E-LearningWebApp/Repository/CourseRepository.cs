using E_LearningWebApp.Data;
using E_LearningWebApp.Models;

namespace E_LearningWebApp.Repository
{
    public class CourseRepository
    {
        private E_LearningDbContext _context;

        public CourseRepository( E_LearningDbContext _context)
        {
            this._context = _context;            
        }
        public Courses AddCourse(Courses course)
        {
            _context.Courses.Add(course);
            _context.SaveChanges();
            return course;
        }
        public List<Courses> GetAllCourses()
        {
            return this._context.Courses.ToList();
        }
        public Courses GetCourseById(int id)
        {
            Courses? courses = this._context.Courses.Find(id);
            return courses;
        }
        public void UpdateCourse(Courses updatedCourse)
        {
            _context.Update(updatedCourse);
            _context.SaveChanges();
        }
        public void DeleteCourse(Courses courses)
        {
            _context.Remove(courses);
            _context.SaveChanges();
        }
    }
}
