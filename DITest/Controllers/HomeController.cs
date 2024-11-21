using System.Diagnostics;
using DITest.Models;
using DITest.Services;
using Microsoft.AspNetCore.Mvc;

namespace DITest.Controllers
{
    public class HomeController : Controller
    {
        private readonly IEmailSenderService _service;
        private static List<EmailMessage> sentEmails = new List<EmailMessage>();

        public HomeController( IEmailSenderService service)
        {
            _service = service;
        }

        public IActionResult Index()
        {
            ViewData["SentEmails"] = sentEmails;
            return View();
        }

        [HttpPost]
        public IActionResult SendEmail(string to, string subject, string body)
        {
            // Create a new email message
            var email = new EmailMessage
            {
                To = to,
                Subject = subject,
                Body = body,
                SentDate = DateTime.Now
            };

            // Simulate sending the email
            bool emailSent = _service.SendEmail(to, subject, body);

            if (emailSent)
            {
                // Add the email to the sent list
                sentEmails.Add(email);
                TempData["SuccessMessage"] = "Email sent successfully!";
            }
            else
            {
                TempData["ErrorMessage"] = "Failed to send email.";
            }

            // Redirect to the Index page to show the sent emails
            return RedirectToAction("Index");
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
