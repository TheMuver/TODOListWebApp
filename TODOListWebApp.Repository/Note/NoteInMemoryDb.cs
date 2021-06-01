using System;
using System.Collections.Generic;
using System.Linq;

namespace TODOListWebApp.Repository
{
    public class NoteInMemoryDb : INoteRepository
    {
        private List<NoteDTO> _data = new List<NoteDTO>();

        public void DeleteNote(NoteDTO note)
        {
            _data.Remove(note);
            note.Id = null;
        }

        public List<NoteDTO> GetNotesByUser(UserDTO user)
        {
            return _data.Where(n => n.User.Equals(user.Login)).ToList();
        }

        public void InsertNote(NoteDTO note)
        {
            note.Id = _data.Count;
            _data.Append(note);
        }

        public void UpdateNote(NoteDTO note)
        {
            DeleteNote(note);
            InsertNote(note);
        }
    }
}