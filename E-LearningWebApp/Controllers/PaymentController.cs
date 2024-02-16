using ChapaNET;
using E_LearningWebApp.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using E_LearningWebApp.Models;
using Microsoft.Extensions.Logging;
using System;
using Newtonsoft.Json;
using System.Diagnostics;

namespace E_LearningWebApp.Controllers
{
    public class PaymentController : Controller
    {


        public async Task<IActionResult> CourseDetailUser()
        {
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync("https://40d1-104-234-212-140.ngrok-free.app/data");

                if (response.IsSuccessStatusCode)
                {
                    string returnUrl = "https://40d1-104-234-212-140.ngrok-free.app/Home/Privacy";
                    // Pass the return URL to the view
                    ViewBag.ReturnUrl = returnUrl;

                    // Parse the response body
                    return View();

                    // Process the response data
                    // Update UI or do other operations
                }
                else
                {
                    // Handle error response
                    // Display error message or log the error
                    string returnUrl = "https://40d1-104-234-212-140.ngrok-free.app/Home/Index";

                    // Pass the return URL to the view
                    ViewBag.ReturnUrl = returnUrl;

                    // Parse the response body
                    return View();


                }
            }

            //   return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}


