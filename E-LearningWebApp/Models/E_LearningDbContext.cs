using Microsoft.EntityFrameworkCore;

namespace E_LearningWebApp.Models
{
    public class E_LearningDbContext : DbContext
    {
        public E_LearningDbContext()
        {

        }

        public E_LearningDbContext(DbContextOptions<E_LearningDbContext> options) : base(options)
        {
        }

        public DbSet<User> User { get; set; }
        public DbSet<Courses> Courses { get; set; }
        public DbSet<Instructor> Instructure { get; set; }
        public DbSet<MyProjects> MyProjects { get; set; }
        public DbSet<SubCourses> SubCourses { get; set; }
        public DbSet<Admin> Admin { get; set; }
        public DbSet<YoutubeVideos> YoutubeVideos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("server=.; Database= MainE_LearningWebApp2; Integrated security = True;");
            }
        }
    }
}
