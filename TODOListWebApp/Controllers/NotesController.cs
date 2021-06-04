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
        public IActionResult Index()
        {
            return File(System.IO.File.ReadAllBytes("Pages/notes.html"), "text/html");
        }

        [HttpGet]
        [Route("notetemplate")]
        public IActionResult GetTemplate() {
            return File(System.IO.File.ReadAllBytes("Pages/note.html"), "text/html");
        }
    }
}