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
            _data.RemoveAt(_data.FindIndex(n => n.Id == note.Id));
            note.Id = null;
        }

        public List<NoteDTO> GetNotesByUser(UserDTO user)
        {
            var list = _data.Where(n => n.User.Equals(user.Login)).ToList();
            for (int i = 0; i < list.Count; i++)
                list[i].Id = i;
            return list;
        }

        public void InsertNote(NoteDTO note)
        {
            note.Id = _data.Count;
            _data.Add(note);
        }

        public void UpdateNote(NoteDTO note)
        {
            DeleteNote(note);
            InsertNote(note);
        }
    }
}