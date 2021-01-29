using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ArchitectDevicesCR.Models;
using Microsoft.AspNetCore.Authorization;
//using Microsoft.AspNetCore.Authorization;
//using System.Security.Claims;

namespace ArchitectDevicesCR.Controllers
{
    //[Authorize(Policy = "RequireAdminRole")]
    [Authorize(Roles = "CanUseApp")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "This site manages all of the CR Architect team electronic devices.";
            
            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Please contact us if needed.";

            return View();
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
