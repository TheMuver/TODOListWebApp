using System;

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
    }
}