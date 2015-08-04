using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TES.Integration.Eventbrite.Classes.Common
{
    public class pagination
    {
        public int object_count { get; set; }
        public int page_number { get; set; }
        public int page_size { get; set; }
        public int page_count { get; set; }
    }
}
