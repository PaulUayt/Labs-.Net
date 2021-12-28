using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SocialNetwork.PL.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace SocialNetwork.PL.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }     
        
        [HttpGet]
        public RedirectResult Autorization()
        {
            return Redirect("/Autorization/Index");
        }

        [HttpGet]
        public RedirectResult Registration()
        {
            return Redirect("/Registration/Registration");
        }
    }
}
