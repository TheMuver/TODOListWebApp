using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TODOListWebApp.Repository
{
    interface INoteRepository
    {
        public void InsertNote(NoteDTO note);

        public void DeleteNote(NoteDTO note);

        public List<NoteDTO> GetNotesByUser(UserDTO user);

        public void UpdateNote(NoteDTO note);
    }
}
