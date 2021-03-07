using BizStream_Full_Stack_Assignment.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.IO;

namespace BizStream_Full_Stack_Assignment.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public ViewResult Index()
        {
            Debug.WriteLine("My debug string here");
            return View();
        }

        [HttpPost]
        public IActionResult Index(ContactFormModel model)
        {
            if (ModelState.IsValid)
            {
                Debug.WriteLine(model.FirstName);
                Debug.WriteLine(model.LastName);
                Debug.WriteLine(model.Email);
                Debug.WriteLine(model.Message);

                WriteOutFile(model.FirstName, model.LastName, model.Email, model.Message);


                return RedirectToAction("Index");
            }
            else
            {
                Debug.WriteLine("Submmit BUtton else");
                return Index();
            }
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public bool WriteOutFile (string firstName, string lastName, string email, string message)
        {
            string time = DateTime.Now.ToString("MM'-'dd'-'yyyy hh:mm tt");
            string timepath = DateTime.Now.ToString("MM'-'dd'-'yyyy hh.mm.tt");
            string fullPath = Path.Combine(System.IO.Directory.GetCurrentDirectory().ToString(), "Contact Message " + timepath+".txt");

            using (StreamWriter writer = new StreamWriter(fullPath))
            {
                writer.WriteLine(time);
                writer.WriteLine(firstName);
                writer.WriteLine(lastName);
                writer.WriteLine(email);
                writer.WriteLine(message);
            }


                return false;
        }

     }

}
