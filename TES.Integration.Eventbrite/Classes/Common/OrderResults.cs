using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TES.Integration.Eventbrite.Classes.Common
{
    public class OrderResults
    {
        public pagination Pagination { get; set; }
        public List<Order> orders { get; set; }
    }

    
}
