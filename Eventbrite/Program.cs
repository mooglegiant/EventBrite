using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using TES.Integration.Eventbrite.Classes.Common;
using TES.Integration.Eventbrite.Classes.Events;
using TES.Integration.Eventbrite.Classes.AttendeeObjects;


namespace Eventbrite
{
    class Program
    {
        static void Main(string[] args)
        {

            Client c = new Client("BIVCD4L6VHRY6WSF2W6V", "79114945937", "https://www.eventbriteapi.com/v3"); // TES
            //Client c = new Client("3KGA5I5TOM3HVPWRERYH", "27839720379", "https://www.eventbriteapi.com/v3"); //Kings Fund
            //EventsResults er = c.GetEvents(); 
            //foreach (var e in er.events)
            //{
            //    Console.WriteLine(e.id);
            //    Console.WriteLine(e.name.text);
            //    Console.WriteLine(e.description.text);
            //}

            //Event e = c.GetEvent("6738465933");
            //Console.WriteLine(e.id);
            //Console.WriteLine(e.name.text);
            ////Console.WriteLine(e.description.text);
            //Console.WriteLine("Capacity: " + e.capacity.ToString());
            //Console.WriteLine(e.status);
            //Console.WriteLine("Online? " + e.online_event.ToString());
            //Console.WriteLine(e.currency);
            //Console.WriteLine("----------------------------------------------------");11387922583

            OrderResults or = c.GetOrders("11387922583");
            foreach (var o in or.orders)
            {
                Console.WriteLine(o.name);
                Console.WriteLine(o.email);
                int i = 0;
                foreach (Attendee a in o.attendees)
                {
                    if (i > 0)
                    {
                        if (a.profile.name != o.attendees[i - 1].profile.name)
                        {
                            Console.WriteLine("    " + a.profile.name);
                            foreach (AttendeeAnswer aa in a.answers)
                            {
                                Console.WriteLine("        Question: " + aa.question);
                                Console.WriteLine("        Answer: " + aa.answer);
                            }
                        }
                    } 
                    i++;
                }
                    
                Console.WriteLine("----------------------------------------------------");
            }


            
            Console.Read();
        }
    }
}
