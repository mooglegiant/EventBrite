using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using TES.Integration.Eventbrite.Classes.Common;
using TES.Integration.Eventbrite.Classes.Events;
using TES.Integration.Eventbrite.Classes.AttendeeObjects;
using TES.Integration.Template.Common;


namespace Eventbrite
{
    class Program
    {
        static void Main(string[] args)
        {
            //When true this displays every purchase, including bulk ticket purchases with repeating information.
            bool displayDuplicateTicketPurchases = true ;
            //This hides and shows the addresses, where applicable, which take up a lot of screen space.
            bool displayAddresses = false;

            #region Authorizations
            //Enable/Disable for accessing different systems.
            Client c = new Client("BIVCD4L6VHRY6WSF2W6V", "79114945937", "https://www.eventbriteapi.com/v3"); // TES
            //Client c = new Client("3KGA5I5TOM3HVPWRERYH", "27839720379", "https://www.eventbriteapi.com/v3"); // Kings Fund

            //Example Event IDs for both TES and Kingsfund. Enable/disable with the above items
            string exampleEventID = "11387922583"; // TES
            //string exampleEventID = "6738465933"; // Kings Fund
            #endregion

            #region Tests Event Functions
            //ServiceResult<EventsResults> er = c.GetEvents();
            //foreach (var e in er.Data.events)
            //{
            //    Console.Write(e.id + ": ");
            //    Console.WriteLine(e.name.text);
            //    //Console.WriteLine(e.description.text);
            //}
            #endregion

            #region Test Further Event Functions
            //ServiceResult<Event> e = c.GetEvent("6738465933");
            //Console.WriteLine(e.Data.id);
            //Console.WriteLine(e.Data.name.text);
            //Console.WriteLine(e.Data.description.text);
            //Console.WriteLine("Capacity: " + e.Data.capacity.ToString());
            //Console.WriteLine(e.Data.status);
            //Console.WriteLine("Online? " + e.Data.online_event.ToString());
            //Console.WriteLine(e.Data.currency);
            //Console.WriteLine("----------------------------------------------------");
            #endregion

            #region Get Total Order
            ServiceResult<OrderResults> or = c.GetOrders(exampleEventID);
            int counter = 0;
            if (or.Success)
            {
                foreach (var o in or.Data.orders)
                {
                    Console.WriteLine("Order Number " + (counter + 1).ToString());
                    Console.WriteLine("Number of Total Orders: " + or.Data.Pagination.object_count.ToString());
                    Console.WriteLine("Number of pages of orders: " + or.Data.Pagination.page_count.ToString());

                    Console.WriteLine(o.name);
                    Console.WriteLine(o.email);
                    int i = 0;

                    foreach (Attendee a in o.attendees)
                    {
                        if (i > 0)
                        {
                            if (a.profile.name != o.attendees[i - 1].profile.name)
                            {
                                Console.WriteLine("    " + i.ToString() + " " + a.profile.name + ": " + a.id);
                                
                                if (a.profile.addresses.home != null || a.profile.addresses.ship != null || a.profile.addresses.work != null)
                                {
                                    if(displayAddresses){
                                        Console.WriteLine("    Addresses");
                                        Console.WriteLine("        Home:");
                                        Console.WriteLine("          " + a.profile.addresses.home.address_1);
                                        Console.WriteLine("          " + a.profile.addresses.home.address_2);
                                        Console.WriteLine("          " + a.profile.addresses.home.city);
                                        Console.WriteLine("          " + a.profile.addresses.home.country);
                                        Console.WriteLine("          " + a.profile.addresses.home.country_name);
                                        Console.WriteLine("          " + a.profile.addresses.home.postal_code);
                                        Console.WriteLine("          " + a.profile.addresses.home.region);
                                        Console.WriteLine("        Ship:");
                                        Console.WriteLine("          " + a.profile.addresses.ship.address_1);
                                        Console.WriteLine("          " + a.profile.addresses.ship.address_2);
                                        Console.WriteLine("          " + a.profile.addresses.ship.city);
                                        Console.WriteLine("          " + a.profile.addresses.ship.country);
                                        Console.WriteLine("          " + a.profile.addresses.ship.country_name);
                                        Console.WriteLine("          " + a.profile.addresses.ship.postal_code);
                                        Console.WriteLine("          " + a.profile.addresses.ship.region);
                                        Console.WriteLine("        Work:");
                                        Console.WriteLine("          " + a.profile.addresses.work.address_1);
                                        Console.WriteLine("          " + a.profile.addresses.work.address_2);
                                        Console.WriteLine("          " + a.profile.addresses.work.city);
                                        Console.WriteLine("          " + a.profile.addresses.work.country);
                                        Console.WriteLine("          " + a.profile.addresses.work.country_name);
                                        Console.WriteLine("          " + a.profile.addresses.work.postal_code);
                                        Console.WriteLine("          " + a.profile.addresses.work.region);
                                    }
                                }
                                foreach (AttendeeAnswer aa in a.answers)
                                {
                                    Console.WriteLine("        Question: " + aa.question);
                                    Console.WriteLine("        Answer: " + aa.answer);
                                }
                            }
                            else if (displayDuplicateTicketPurchases)
                            {
                                Console.WriteLine("    " + i.ToString() + " " + a.profile.name + ": " + a.id);
                                
                                if (a.profile.addresses.home != null || a.profile.addresses.ship != null || a.profile.addresses.work != null)
                                {
                                    if (displayAddresses)
                                    {
                                        Console.WriteLine("    Addresses");
                                        Console.WriteLine("        Home:");
                                        Console.WriteLine("          " + a.profile.addresses.home.address_1);
                                        Console.WriteLine("          " + a.profile.addresses.home.address_2);
                                        Console.WriteLine("          " + a.profile.addresses.home.city);
                                        Console.WriteLine("          " + a.profile.addresses.home.country);
                                        Console.WriteLine("          " + a.profile.addresses.home.country_name);
                                        Console.WriteLine("          " + a.profile.addresses.home.postal_code);
                                        Console.WriteLine("          " + a.profile.addresses.home.region);
                                        Console.WriteLine("        Ship:");
                                        Console.WriteLine("          " + a.profile.addresses.ship.address_1);
                                        Console.WriteLine("          " + a.profile.addresses.ship.address_2);
                                        Console.WriteLine("          " + a.profile.addresses.ship.city);
                                        Console.WriteLine("          " + a.profile.addresses.ship.country);
                                        Console.WriteLine("          " + a.profile.addresses.ship.country_name);
                                        Console.WriteLine("          " + a.profile.addresses.ship.postal_code);
                                        Console.WriteLine("          " + a.profile.addresses.ship.region);
                                        Console.WriteLine("        Work:");
                                        Console.WriteLine("          " + a.profile.addresses.work.address_1);
                                        Console.WriteLine("          " + a.profile.addresses.work.address_2);
                                        Console.WriteLine("          " + a.profile.addresses.work.city);
                                        Console.WriteLine("          " + a.profile.addresses.work.country);
                                        Console.WriteLine("          " + a.profile.addresses.work.country_name);
                                        Console.WriteLine("          " + a.profile.addresses.work.postal_code);
                                        Console.WriteLine("          " + a.profile.addresses.work.region);
                                    }
                                }
                                foreach (AttendeeAnswer aa in a.answers)
                                {
                                    Console.WriteLine("        Question: " + aa.question);
                                    Console.WriteLine("        Answer: " + aa.answer);
                                }
                            }
                        }
                        else
                        {
                            Console.WriteLine("    " + i.ToString() + " " + a.profile.name + ": " + a.id);
                            
                            if (a.profile.addresses.home != null || a.profile.addresses.ship != null || a.profile.addresses.work != null)
                            {
                                if (displayAddresses)
                                {
                                    Console.WriteLine("    Addresses");
                                    Console.WriteLine("        Home:");
                                    Console.WriteLine("          " + a.profile.addresses.home.address_1);
                                    Console.WriteLine("          " + a.profile.addresses.home.address_2);
                                    Console.WriteLine("          " + a.profile.addresses.home.city);
                                    Console.WriteLine("          " + a.profile.addresses.home.country);
                                    Console.WriteLine("          " + a.profile.addresses.home.country_name);
                                    Console.WriteLine("          " + a.profile.addresses.home.postal_code);
                                    Console.WriteLine("          " + a.profile.addresses.home.region);
                                    Console.WriteLine("        Ship:");
                                    Console.WriteLine("          " + a.profile.addresses.ship.address_1);
                                    Console.WriteLine("          " + a.profile.addresses.ship.address_2);
                                    Console.WriteLine("          " + a.profile.addresses.ship.city);
                                    Console.WriteLine("          " + a.profile.addresses.ship.country);
                                    Console.WriteLine("          " + a.profile.addresses.ship.country_name);
                                    Console.WriteLine("          " + a.profile.addresses.ship.postal_code);
                                    Console.WriteLine("          " + a.profile.addresses.ship.region);
                                    Console.WriteLine("        Work:");
                                    Console.WriteLine("          " + a.profile.addresses.work.address_1);
                                    Console.WriteLine("          " + a.profile.addresses.work.address_2);
                                    Console.WriteLine("          " + a.profile.addresses.work.city);
                                    Console.WriteLine("          " + a.profile.addresses.work.country);
                                    Console.WriteLine("          " + a.profile.addresses.work.country_name);
                                    Console.WriteLine("          " + a.profile.addresses.work.postal_code);
                                    Console.WriteLine("          " + a.profile.addresses.work.region);
                                }
                            }

                            foreach (AttendeeAnswer aa in a.answers)
                            {
                                Console.WriteLine("        Question: " + aa.question);
                                Console.WriteLine("        Answer: " + aa.answer);
                            }
                        }
                        i++;
                    }
                    counter++;
                    Console.WriteLine("----------------------------------------------------");
                }
            }
            else
            {
                Console.WriteLine(or.Message);
            }


            #endregion
            
            
            Console.Read();
            
        }
    }
}
