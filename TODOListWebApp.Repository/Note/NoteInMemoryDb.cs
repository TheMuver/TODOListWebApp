using System;
using System.Collections.Generic;
using System.Linq;

namespace TODOListWebApp.Repository.Note
{
    public class NoteInMemoryDb : INoteRepository
    {
        // Ну вот захотелось мне сделать все исключительно через интерфейс коллекций...
        private IEnumerable<NoteDTO> _data = new List<NoteDTO>();

        public void DeleteNote(NoteDTO note)
        {
            _data = _data.Except(new NoteDTO[] { note });
        }

        public List<NoteDTO> GetNotesByUser(UserDTO user)
        {
            return _data.Where(n => n.User.Equals(user.Login)).ToList();
        }

        public void InsertNote(NoteDTO note)
        {
            _data.Append(note);
        }

        public void UpdateNote(NoteDTO note)
        {
            _data
        }
    }
}