using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TES.Integration.Eventbrite.Classes.Common
{
    public class OrderCosts
    {
        public Currency gross { get; set; }
        public Currency eventbrite_fee { get; set; }
        public Currency payment_fee { get; set; }
        public Currency tax { get; set; }
    }
}
