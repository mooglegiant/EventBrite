using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TES.Integration.Eventbrite.Classes.Common;

namespace TES.Integration.Eventbrite.Classes.Events
{
    public class Event
    {
        public string id { get; set; }
        public MultipartName name { get; set; }
        public MultipartName description { get; set; }
        public string url { get; set; }
        public MultipartDate start { get; set; }
        public MultipartDate end { get; set; }
        public DateTime created { get; set; }
        public DateTime changed { get; set; }
        public int capacity { get; set; }
        public string status { get; set; }
        public string currency { get; set; }
        public bool online_event { get; set; }
    }
}
