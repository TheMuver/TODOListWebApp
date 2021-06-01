using System.Net;
using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TODOListWebApp.Controllers
{
    [Authorize]
    public class NotesController : Controller
    {
        [HttpGet]
        [Route("notes")]
        public IActionResult About()
        {
            return File(System.IO.File.ReadAllBytes("Pages/notes.html"), "text/html");
        }
    }
}