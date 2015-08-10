using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TES.Integration.Eventbrite.Classes.Events;

namespace TES.Integration.Eventbrite.Classes.Common
{
    public class Ticket
    {
        public Event MyProperty { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public Currency cost { get; set; }
        public Currency fee { get; set; }
        public bool donation { get; set; }
        public bool free { get; set; }
        public int maximum_quantity { get; set; }
        public int minimum_dquantity { get; set; }
    }
}
