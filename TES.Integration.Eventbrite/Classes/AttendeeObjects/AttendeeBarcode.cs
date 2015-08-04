using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TES.Integration.Eventbrite.Classes.AttendeeObjects
{
    public class AttendeeBarcode
    {
        public string barcode { get; set; }
        public string status { get; set; }
        public DateTime created { get; set; }
        public DateTime changed { get; set; }
    }
}
