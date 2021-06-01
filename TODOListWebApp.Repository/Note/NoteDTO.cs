using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TODOListWebApp.Repository
{
    public class NoteDTO
    {   
        public int? Id { get; set; }

        public string User { get; set; }

        public string Text { get; set; }

        public override bool Equals(object obj)
        {
            if (obj is NoteDTO) 
            {
                return Id == ((NoteDTO)obj).Id;
            }
            return base.Equals(obj);
        }
    }
}
