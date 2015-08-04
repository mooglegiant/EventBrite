using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using TES.Integration.Eventbrite.Classes.Common;
using TES.Integration.Eventbrite.Classes.Events;


namespace Eventbrite
{
    class Program
    {
        static void Main(string[] args)
        {

            Client c = new Client("BIVCD4L6VHRY6WSF2W6V", "79114945937", "https://www.eventbriteapi.com/v3");
            EventsResults er = c.GetEvents();
            foreach (var e in er.events)
            {
                Console.WriteLine(e.id);
            }
            Console.Read();
        }
    }
}
