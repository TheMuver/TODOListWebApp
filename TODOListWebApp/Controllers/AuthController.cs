using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TODOListWebApp.Controllers
{
    public class AuthController : Controller
    {
        [HttpGet]
        [Route("login")]
        public IActionResult GetLoginPage() 
        {						
            return File(System.IO.File.ReadAllBytes("Pages/login.html"), "text/html");
        }

        [HttpGet]
        [Route("signup")]
        public IActionResult GetSignupPage() 
        {
            return File(System.IO.File.ReadAllBytes("Pages/signup.html"), "text/html");
        }
    }
}