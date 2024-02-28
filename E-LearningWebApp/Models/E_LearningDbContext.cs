using E_LearningWebApp.Areas.Identity.Data;
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

        /*        public DbSet<User> User { get; set; }
        */
        public DbSet<Grade> Grades { get; set; }
        public DbSet<Payment> Payment { get; set; }

        public DbSet<Courses> Courses { get; set; }
     
/*        public DbSet<MyProjects> MyProjects { get; set; }
*/        public DbSet<SubCourses> SubCourses { get; set; }
 
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           /* modelBuilder.Entity<Courses>()
         .HasOne(c => c.Payment) // Use the renamed navigation property
         .WithOne(p => p.Course) // Use the renamed navigation property
         .HasForeignKey<Payment>(p => p.CourseId); // Configure the foreign key


*//*
            modelBuilder.Entity<E_LearningWebAppUser>()
                .HasMany(u => u.payments) // A User can have many Payments
                .WithOne(p => p.User) // A Payment can belong to one User
                .HasForeignKey(p => p.Id); // Foreign key for User*/





            modelBuilder.Entity<Grade>()
                .HasOne(g => g.User) // Navigation property on the Grade entity
                .WithMany(u => u.grades) // Collection navigation property on the E_LearningWebAppUser entity
                .HasForeignKey(g => g.Userid);

/*
            modelBuilder.Entity<Admin>(entity =>
            {
                entity.ToTable("E_LearningWebAppUser");

                entity.Property(e => e.AdminId).HasColumnName("Id");

                entity.Property(e => e.Password)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("Password")
                    .IsFixedLength(true);

                entity.Property(e => e.Username)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("Username");
            });*/
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("server=.; Database= MainE_LearningWebApp18; Integrated security = True;");
            }
        }
    }
}
