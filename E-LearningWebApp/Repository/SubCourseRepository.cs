using E_LearningWebApp.Models;

namespace E_LearningWebApp.Repository
{
    public class SubCourseRepository
    {
        private E_LearningDbContext _context;
        public SubCourseRepository(E_LearningDbContext _context)
        {
            this._context = _context;
        }
        public SubCourses AddSubCourse(SubCourses course)
        {
            _context.SubCourses.Add(course);
            _context.SaveChanges();
            return course;
        }
        public List<SubCourses> GetAllSubCourse()
        {
            return this._context.SubCourses.ToList();
        }
        public SubCourses GetSubCourseById(int id)
        {
            SubCourses? SubCourses = this._context.SubCourses.Find(id);
            return SubCourses;
        }
        public void UpdateSubCourse(SubCourses updatedCourse)
        {
            _context.Update(updatedCourse);
            _context.SaveChanges();
        }
        public void DeleteSubCourse(SubCourses courses)
        {
            _context.Remove(courses);
            _context.SaveChanges();
        }
    }
}
