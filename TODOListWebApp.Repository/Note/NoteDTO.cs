using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TODOListWebApp.Repository
{
    class NoteDTO
    {   
        public int? Id { get; set; }

        public string User { get; set; }

        public string Text { get; set; }

        public DateTime EditTime { get; set; }

        public DateTime DeadlineTime { get; set; }
    }
}
