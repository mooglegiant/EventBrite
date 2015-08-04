using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TES.Integration.Eventbrite.Classes.Common
{
    public class pagination
    {
        public string object_count { get; set; }
        public string page_number { get; set; }
        public string page_size { get; set; }
        public string page_count { get; set; }
    }
}
