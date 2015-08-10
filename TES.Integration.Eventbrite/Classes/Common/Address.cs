using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TES.Integration.Eventbrite.Classes.Common
{
    public class Address
    {
        public string address_1 { get; set; }
        public string address_2 { get; set; }
        public string city { get; set; }
        public string region { get; set; }
        public string postal_code { get; set; }
        public string country { get; set; }
        public string country_name { get; set; }
    }
}
