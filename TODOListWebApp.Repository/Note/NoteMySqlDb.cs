using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

using MySql.Data.MySqlClient;
using Dapper;


namespace TODOListWebApp.Repository
{
    public class NoteMySqlDb : INoteRepository
    {
        public void InsertNote(NoteDTO note)
        {
            using (IDbConnection db = new MySqlConnection(Resources.CONNECTIONSTRING))
            {
                // Не делать CTRL+C, другая база может упасть с primary id always is 0, но MySql это съедает спокойно, экономя мне десяток символов. 
                string sqlQuery = "insert into note values (0, @User, @Content, @EditTime, @DeadlineTime)";
                db.Execute(sqlQuery, note);

                // Не работает с параллельностью, но пока, надеюсь, сойдёт.
                int i = db.Query<int>("select max(note.id) from note " +
                    "where @Content = note.content and @DeadlineTime = note.deadline_time and @EditTime = note.edit_time", note).First();
                note.Id = i;
            }
        }

        public List<NoteDTO> GetNotesByUser(UserDTO user)
        {
            List<NoteDTO> notes = new List<NoteDTO>();
            using (IDbConnection db = new MySqlConnection(Resources.CONNECTIONSTRING))
            {
                string sqlQuery = "select * from note where @Login = note.user";
                notes = db.Query<NoteDTO>(sqlQuery, user).ToList();
            }
            return notes;
        }

        public void UpdateNote(NoteDTO note)
        {
            using (IDbConnection db = new MySqlConnection(Resources.CONNECTIONSTRING))
            {
                string sqlQuery = "update note set content = @Text, user = @User, edit_time = @EditTime, deadline_time = @DeadlineTime where id = @Id";
                db.Execute(sqlQuery, note);
            }
        }

        public void DeleteNote(NoteDTO note)
        {
            using (IDbConnection db = new MySqlConnection(Resources.CONNECTIONSTRING))
            {
                string sqlQuery = "delete note where @Id = id";
                db.Execute(sqlQuery, note);
            }
        }
    }
}
