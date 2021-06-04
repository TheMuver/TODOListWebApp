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
        [Route("getallnotes")]
        public List<Note> GetAllNotes() {
            Console.WriteLine(HttpContext.User.Claims.Count());
            User u = new User();
            return _data.GetNotesByUser(u.ToDTO()).ConvertAll<Note>(dto => new Note(dto));
        }

        [HttpPost]
        [Route("addnote")]
        public IActionResult AddNote([FromBody] Note note) {
            _data.InsertNote(note.ToDTO());
            return Ok();
        }

        [HttpDelete]
        [Route("deletenote")]
        public IActionResult DeleteNote([FromBody] Note note) {
            _data.DeleteNote(note.ToDTO());
            return Ok();
        }

        [HttpPut]
        [Route("updatenote")]
        public IActionResult UpdateNote([FromBody] Note note) {
            _data.UpdateNote(note.ToDTO());
            return Ok();
        }
    }
}