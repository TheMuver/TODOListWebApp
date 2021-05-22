using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TODOListWebApp.Controllers
{
    public class MainController : Controller
    {
        public string Index()
        {
            return "Hello world!";
        }

        public IActionResult GetSomething()
        {
            return View();
        }
    }
}
