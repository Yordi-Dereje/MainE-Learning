using E_LearningWebApp.Areas.Identity.Data;
using E_LearningWebApp.Data;
using E_LearningWebApp.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Security.Principal;

namespace E_LearningWebApp.Controllers
{
    public class UserController : Controller
    {
        private E_LearningDbContext _context = new E_LearningDbContext();
        private readonly UserManager<E_LearningWebAppUser> _userManager;
        private E_LearningWebAppContext _appContext;
        public UserController(UserManager<E_LearningWebAppUser> _userManager, E_LearningWebAppContext _appContext)
        {
            this._userManager = _userManager;
            this._appContext = _appContext;

        }
        [HttpGet]
        public async Task<IActionResult> Index([FromQuery]string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            return View(user);
        }
        [HttpGet]
        public IActionResult ListUsers() 
        {
            var users = _userManager.Users.ToList();
            return View(users);

        }
        public async Task<IActionResult> UpdateUser(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
                ViewBag.ErrorMessage = $"User with Id = {id} cannot be found";
                return View("NorFound");
            }
            else
            {
                var result = await _userManager.UpdateAsync(user);
                return View(result);
            }
        }
        public async Task<IActionResult> DeleteUser(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
                ViewBag.ErrorMessage = $"User with Id = {id} cannot be found";
                return View("NorFound");
            }
            else
            {
                var result = await _userManager.DeleteAsync(user);
                return View(result);
            }
        }
        [HttpGet]
        public async Task<IActionResult> Profile([FromQuery] string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                return NotFound($"Unable to find '{userId}'.");
            }
            else
            {
                return View(user);
            }
        }
        //[HttpPost]


    }
}
