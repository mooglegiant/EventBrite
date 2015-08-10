using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TES.Integration.Eventbrite.Classes.AttendeeObjects
{
    public class AttendeeProfile
    {
        public string name { get; set; }
        public string email { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string prefix { get; set; }
        public string suffix { get; set; }
        public int age { get; set; }
        public string job_title { get; set; }
        public string company { get; set; }
        public string website { get; set; }
        public string blog { get; set; }
        public string gender { get; set; }
        public DateTime birth_date { get; set; }
        public string cell_phone { get; set; }
        public AttendeeAddress addresses { get; set; }
    }
}
