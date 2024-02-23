using E_LearningWebApp.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using E_LearningWebApp.Models;
using Microsoft.AspNetCore.Identity;
using E_LearningWebApp.Areas.Identity.Data;
using Microsoft.AspNetCore.Authentication.Cookies;
/*using Microsoft.AspNetCore.Authentication.Google;*/
using Microsoft.AspNetCore.Authentication;

namespace E_LearningWebApp.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        E_LearningDbContext _context = new E_LearningDbContext();
        private readonly SignInManager<E_LearningWebAppUser> signInManager;
        public AccountController(SignInManager<E_LearningWebAppUser> signInManager)
        {
            this.signInManager = signInManager;
        }
        [HttpGet]
        /*    public async IActionResult Login(E_LearningWebAppUser user,string returnUrl)
            {
                if(ModelState.IsValid)
                {
                    var result = await signInManager.CheckPasswordSignInAsync(user.Email, user.PasswordHash, false);
                }
                return View();
            }
    */
        /*public async Task Login()
        {
            await HttpContext.ChallengeAsync(GoogleDefaults.AuthenticationScheme,
                new AuthenticationProperties
                {
                    RedirectUri = Url.Action("GoogleResponse")
                });
        }*/
        /*public async Task<IActionResult> GoogleResponse()
        {
            var result = await HttpContext.AuthenticateAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            var claims = result.Principal.Identities.FirstOrDefault().Claims.Select(claim => new
            {
                claim.Issuer,
                claim.OriginalIssuer,
                claim.Type,
                claim.Value
            });
            return Json(claims);
        }*/
            public ActionResult verify(AdminController add, E_LearningWebAppUser user)
        {
            return View();
        }

    }
}

       
    