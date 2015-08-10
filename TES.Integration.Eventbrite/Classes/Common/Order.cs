using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TES.Integration.Eventbrite.Classes.Events;
using TES.Integration.Eventbrite.Classes.AttendeeObjects;

namespace TES.Integration.Eventbrite.Classes.Common
{
    public class Order
    {
        public string id { get; set; }
        public DateTime created { get; set; }
        public DateTime changed { get; set; }
        public string name { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string email { get; set; }
        public OrderCosts costs { get; set; }

        public string event_id { get; set; }
        public List<Attendee> attendees { get; set; }

        public Order()
        {
                
        }
    }
}
