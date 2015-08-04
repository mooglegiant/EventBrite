using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TES.Integration.Eventbrite.Classes.AttendeeObjects
{
    public class AttendeeTeam
    {
        public string id { get; set; }
        public string name { get; set; }
        public DateTime date_joined { get; set; }
        public string event_id { get; set; }
    }
}
