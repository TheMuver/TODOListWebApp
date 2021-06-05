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
        INoteRepository _data;

        public NotesApiController(INoteRepository data) {
            _data = data;
        }

        [HttpGet]
        [Route("note.getall")]
        public Note[] GetAllNotes() {
            User u = new User(getUserName(), "");
            return _data.GetNotesByUser(u.ToDTO()).ConvertAll<Note>(dto => new Note(dto)).ToArray();
        }

        [HttpPost]
        [Route("note.add")]
        public IActionResult AddNote([FromBody] Note note) {
            note.User = getUserName();
            _data.InsertNote(note.ToDTO());
            return Ok();
        }

        [HttpDelete]
        [Route("note.delete")]
        public IActionResult DeleteNote([FromBody] Note note) {
            note.User = getUserName();
            _data.DeleteNote(note.ToDTO());
            return Ok();
        }

        [HttpPost]
        [Route("note.update")]
        public IActionResult UpdateNote([FromBody] Note note) {
            note.User = getUserName();
            _data.UpdateNote(note.ToDTO());
            return Ok();
        }

        [HttpGet]
        [Route("note.template")]
        public string GetTemplate() {
            return System.IO.File.ReadAllText("Pages/note.html");
        }

        private string getUserName() {
            return HttpContext.User.Claims.First(c => c.Type == "Login").Value;
        }
    }
}