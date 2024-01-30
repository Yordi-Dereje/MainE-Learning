using E_LearningWebApp.Areas.Identity.Data;
using E_LearningWebApp.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace E_LearningWebApp.Data;

public class E_LearningWebAppContext : IdentityDbContext<E_LearningWebAppUser>
{
    public E_LearningWebAppContext(DbContextOptions<E_LearningWebAppContext> options)
        : base(options)
    {
    }

    

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);
    }
}
