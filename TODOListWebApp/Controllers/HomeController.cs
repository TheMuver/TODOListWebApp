using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TODOListWebApp.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            return File(System.IO.File.ReadAllBytes("Pages/index.html"), "text/html");
        }

        [HttpGet]
        [Route("about")]
        public IActionResult About()
        {
            return File(System.IO.File.ReadAllBytes("Pages/about.html"), "text/html");
        }
    }
}