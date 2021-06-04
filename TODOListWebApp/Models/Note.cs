using System;
using TODOListWebApp.Repository;

namespace TODOListWebApp
{
    public class Note
    {
        public int? Id { get; set; }

        public string User { get; set; }

        public string Text { get; set; }

        public Note() { }

        public Note(string user, string text) 
        {
            User = user;
            Text = text;
        }

        public Note(NoteDTO dto) 
        {
            Id = dto.Id;
            User = dto.User;
            Text = dto.Text;
        }

        public NoteDTO ToDTO() {
            return new NoteDTO() {Id = this.Id, User = this.User, Text = this.Text };
        }

        public override bool Equals(object obj)
        {
            if (obj is Note) 
            {
                return Id == ((Note)obj).Id;
            }
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return $"Note: {Id} {User} {Text}";
        }
    }
}