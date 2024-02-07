using E_LearningWebApp.Areas.Identity.Data;
using E_LearningWebApp.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace E_LearningWebApp.Data;

public class E_LearningWebAppContext : IdentityDbContext<E_LearningWebAppUser>
{
    public E_LearningWebAppContext()
    {
    }

    public E_LearningWebAppContext(DbContextOptions<E_LearningWebAppContext> options)
        : base(options)
    {
    }

  

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<Courses>()
           .HasOne(c => c.Payment) // Use the renamed navigation property
           .WithOne(p => p.Course) // Use the renamed navigation property
           .HasForeignKey<Payment>(p => p.CourseId); // Configure the foreign key
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);
    }
}
