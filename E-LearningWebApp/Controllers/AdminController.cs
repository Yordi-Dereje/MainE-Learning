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




        public IActionResult DashBoard() { return View(); }

       // [Authorize(Policy = "Adminroles")]
        public IActionResult Index()
        {
            ViewBag.userid = _userManager.GetUserId(HttpContext.User);
            return View();
        }
        
    }
}
