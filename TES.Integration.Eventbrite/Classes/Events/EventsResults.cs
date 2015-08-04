using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TES.Integration.Eventbrite.Classes.Common;

namespace TES.Integration.Eventbrite.Classes.Events
{
    public class EventsResults
    {
        public pagination Pagination { get; set; }
        public List<Event> events { get; set; }
    }
}
