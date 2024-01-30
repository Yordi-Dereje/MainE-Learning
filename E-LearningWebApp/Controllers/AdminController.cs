using E_LearningWebApp.Areas.Identity.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;

namespace E_LearningWebApp.Controllers
{
    //[Authorize(Policy = "Adminroles")]
    public class AdminController : Controller
    {
        private readonly UserManager<E_LearningWebAppUser> _userManager;
        public AdminController(UserManager<E_LearningWebAppUser> userManager)
        {
            _userManager = userManager;
        }

        public IActionResult DashBoard() { return View(); }

        public IActionResult Index()
        {
            ViewBag.userid = _userManager.GetUserId(HttpContext.User);
            return View();
        }
    }
}
