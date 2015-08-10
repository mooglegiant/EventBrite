using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TES.Integration.Eventbrite.Classes.Common;

namespace TES.Integration.Eventbrite.Classes.AttendeeObjects
{
    public class AttendeeAddress
    {
        public Address home { get; set; }
        public Address ship { get; set; }
        public Address work { get; set; }

        
    }
}
