using E_LearningWebApp.Areas.Identity.Data;
using E_LearningWebApp.Data;
using E_LearningWebApp.Models;
using Microsoft.EntityFrameworkCore;

namespace E_LearningWebApp.Repository
{
    public class UserRepository
    {
        private E_LearningWebAppContext _appcontext;
        public UserRepository(E_LearningWebAppContext _appcontext)
        {
            this._appcontext = _appcontext;
            
        }
       /* public void Updateuser(E_LearningWebAppUser updateuser)
        {
            var updated = _appcontext.E_LearningWebAppUser.Find(p => p.id == updatedCourse.CourseId);
            if (updated != null)
            {
                _context.Courses.Update(updated);
                _context.SaveChanges();
            }
        }*/
    }
}
