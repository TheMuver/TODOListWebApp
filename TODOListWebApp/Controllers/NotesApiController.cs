using System.Security.Claims;
using System.Runtime.Intrinsics.X86;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using TODOListWebApp.Repository;

namespace TODOListWebApp.Controllers
{
    [Authorize]
    public class NotesApiController : ControllerBase
    {
        [HttpGet]
        [Route("getallnotes")]
        public List<Note> GetAllNotes() 
        {
            Console.WriteLine(HttpContext.User.Claims.First(c => true).Value);
            return new List<Note>();
        }
    }
}