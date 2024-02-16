using E_LearningWebApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Net.Mail;
using System.Net;

namespace E_LearningWebApp.Controllers
{
    /*[Authorize]*/
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Courses()
        {
            return View();
        }
        public IActionResult ContactUss()
        {
            return View();
        }

        [Authorize(Policy = "Adminroles")]
        public IActionResult Privacy()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SendEmail(string email, string Subject, string message, string password)
        {
            // Configure the email settings
            string senderEmail = email;
            string senderPassword = password;
            string recipientEmail = "goldenlady0940@gmail.com";
            string subject = Subject;
            string body = message;

            // Create the email message
            MailMessage mail = new MailMessage(senderEmail, recipientEmail, subject, body);
            mail.IsBodyHtml = false; // Set to true if you want to send HTML email

            // Setup the SMTP client
            SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587);
            smtpClient.EnableSsl = true; // Set to true if your email server requires SSL
            /*            smtpClient. Credentials = CredentialCache.DefaultNetworkCredentials;
            */
            smtpClient.UseDefaultCredentials = true;
            smtpClient.Credentials = new NetworkCredential(senderEmail, senderPassword);


                smtpClient.Send(mail);
                ViewBag.Message = "Email sent successfully.";
           
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}