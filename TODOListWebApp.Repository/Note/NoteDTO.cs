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
                if (Id != null)
                    return Id == ((NoteDTO)obj).Id;
                else
                    return false;
            }
            return base.Equals(obj);
        }
    }
}
