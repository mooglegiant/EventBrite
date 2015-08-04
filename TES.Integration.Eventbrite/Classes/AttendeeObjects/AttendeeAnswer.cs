using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TES.Integration.Eventbrite.Classes.AttendeeObjects
{
    public class AttendeeAnswer
    {
        public string question_id { get; set; }
        public string question { get; set; }
        public string type { get; set; }
        public string answer { get; set; }
    }
}
