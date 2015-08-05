using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TES.Integration.Eventbrite.Classes.AttendeeObjects;
using TES.Integration.Eventbrite.Classes.Common;

namespace TES.Integration.Eventbrite.Classes.AttendeeObjects
{
    public class Attendee
    {
        public DateTime created { get; set; }
        public DateTime changed { get; set; }
        public string ticket_class_id { get; set; }
        public AttendeeProfile profile { get; set; }
        public List<AttendeeAddress> addresses { get; set; }
        public List<AttendeeAnswer> answers { get; set; }
        public List<AttendeeBarcode> barcodes { get; set; }
        public AttendeeTeam team { get; set; }

        public string event_id { get; set; }
        public string order_id { get; set; }
    }
}
