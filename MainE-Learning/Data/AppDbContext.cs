using MainE_Learning.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MainE_Learning.Data
{
    public class AppDbContext : IdentityDbContext<AppUser>
    {
        public AppDbContext()
        {
            
        }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }
        public DbSet<User> User { get; set; }
        public DbSet<Courses> Courses { get; set; }
        public DbSet<Instructor> Instructure { get; set; }
        public DbSet<MyProjects> MyProjects { get; set; }
        public DbSet<SubCourses> SubCourses { get; set; }
        public DbSet<Admin> Admin { get; set; }
        public DbSet<YoutubeVideos> YoutubeVideos { get; set;}

      

    }
}
