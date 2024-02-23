using E_LearningWebApp.Areas.Identity.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using E_LearningWebApp.Models;
using E_LearningWebApp.Repository;
using ChapaNET;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using E_LearningWebApp.Data;

namespace E_LearningWebApp.Controllers
{
    [Authorize]
  //  [Authorize(Policy = "Adminroles")]
    public class AdminController : Controller
    {

        private E_LearningDbContext _context = new E_LearningDbContext();

        private readonly UserManager<E_LearningWebAppUser> _userManager;
        public AdminController(UserManager<E_LearningWebAppUser> userManager)
        {
            _userManager = userManager;
        }



        [HttpPost]
        [Route("payment/callback")]
        public IActionResult PaymentCallback([FromBody] dynamic payload)
        {
            try
            {
                // Extract payment details from the payload
                var transactionRef = payload?.tx_ref;
                var status = payload?.status;

                // Validate the callback (this will depend on Chapa's requirements)

                // Process the payment status
                if (status == "successful")
                {
                    // Update your application state to reflect a successful payment
                }
                else
                {
                    // Handle other payment statuses as needed
                }

                // Send a response to acknowledge receipt of the callback
                return Ok();
            }
            catch (Exception ex)
            {
                // Log the exception for debugging purposes

                // Respond with an error status code
                return BadRequest(ex.Message);
            }
        }
        [HttpGet]
        public async Task<IActionResult> ProfileAsync([FromQuery] string userid)
        {
            var user = await _userManager.FindByIdAsync(userid);
            if (user == null)
            {
                return NotFound($"Unable to find '{userid}'.");
            }
            else
            {
                return View(user);
            }
        }
        [HttpPost]
        public async Task<IActionResult> Profile([FromQuery] string userid, [FromForm] E_LearningWebAppUser userdata)
        {

            var user = await _userManager.FindByIdAsync(userid);
            if (user == null)
            {
                return NotFound($"Unable to find '{userid}'.");
            }
            else
            {
                user.FirstName = userdata.FirstName;
                user.LastName = userdata.LastName;
                user.PhoneNumber = userdata.PhoneNumber;
                user.UserName = userdata.UserName;

                var result = await _userManager.UpdateAsync(user);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Admin");
                }
                else
                {
                    // Handle errors
                    return View(user);
                }
            }
        }

        // [Authorize(Policy = "Adminroles")]
        public IActionResult Index()
        {
            int countCourse = _context.Courses.Count();
            ViewBag.ItemCountCourse = countCourse;

            int countSubCourse = _context.SubCourses.Count();
            ViewBag.ItemCountSubCourse = countSubCourse;

            var userCount = _userManager.Users.Count();
            ViewBag.UserCount = userCount;
            /*            ViewBag.userid = _userManager.GetUserId(HttpContext.User);
            */
            return View();
        }
        
    }
}
