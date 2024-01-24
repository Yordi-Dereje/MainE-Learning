using MainE_Learning.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace MainE_Learning.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> userManager;
        private readonly IPasswordHasher<AppUser> passwordHasher;

        public AccountController(UserManager<AppUser> userManager, IPasswordHasher<AppUser> passwordHasher)
        {
            this.userManager = userManager;
            this.passwordHasher = passwordHasher;
        }

        public IActionResult Index()
        {
            return View(userManager.Users);
        }
        [HttpGet]
        public ViewResult Create() => View();

        [HttpPost]
        public async Task<IActionResult> Create(User user)
        {
            if (ModelState.IsValid)
            {
                AppUser appuser = new AppUser() { UserName = user.FullName, Email = user.Email };
                IdentityResult result = await userManager.CreateAsync(appuser, user.Password);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    foreach (IdentityError error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }
            }
            return View(user);
        }
    }
}
