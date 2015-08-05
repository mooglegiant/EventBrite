using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using Newtonsoft.Json;
using TES.Integration.Eventbrite.Classes.Events;
using TES.Integration.Eventbrite.Classes.AttendeeObjects;

namespace TES.Integration.Eventbrite.Classes.Common
{
    public class Client
    {
        //properties
        public string _token { get; set; }
        public string _eb_user { get; set; }
        public string _baseURL { get; set; }
        
        //constructor
        public Client(string token, string eb_user, string baseURL)
        {
            _token = token;
            _eb_user = eb_user;
            _baseURL = baseURL;
        }

        //variables
        WebClient client;

        //functions

        /// <summary>
        /// This function returns every Event associated with an account as an 'EventsResults'
        /// </summary>
        /// <returns>EventsResults</returns>
        public EventsResults GetEvents()
        {
            GetClient();
            var url = string.Format("{0}/users/{1}/events/?token={2}", _baseURL, _eb_user, _token);
            var result = client.DownloadString(url);
            return JsonConvert.DeserializeObject<EventsResults>(result);
        }
        /// <summary>
        /// This function returns a single Event, as dictated by the eventId given.
        /// </summary>
        /// <param name="eventId"></param>
        /// <returns>Event</returns>
        public Event GetEvent(string eventId)
        {
            GetClient();
            var url = string.Format("{0}/events/{1}/?token={2}", _baseURL, eventId, _token);
            var result = client.DownloadString(url);
            return JsonConvert.DeserializeObject<Event>(result);
        }
        /// <summary>
        /// This returns a list of Orders, as an 'OrderResults,' associated with the event of the given ID.
        /// </summary>
        /// <param name="eventId"></param>
        /// <returns>OrderResults</returns>
        public OrderResults GetOrders(string eventId)
        {
            GetClient();
            var url = string.Format("{0}/events/{1}/orders/?token={2}", _baseURL, eventId, _token);
            var result = client.DownloadString(url);
            OrderResults oResults = JsonConvert.DeserializeObject<OrderResults>(result);
            AttendeeResults aResults = GetAttendees(eventId);
            OrderResults finalResults = new OrderResults();
            finalResults.Pagination = oResults.Pagination;
            if (oResults.Pagination.page_count > 1)
            {
                for (int i = 0; i < oResults.Pagination.page_count; i++)
                {
                    var tUrl = string.Format("{0}/events/{1}/orders/?token={2}&page={3}", _baseURL, eventId, _token, i + 1);
                    var tResult = client.DownloadString(tUrl);
                    OrderResults tResults = JsonConvert.DeserializeObject<OrderResults>(tResult);
                    if (finalResults.orders == null)
                        finalResults.orders = new List<Order>();
                    if (tResults.orders != null)
                        finalResults.orders.AddRange(tResults.orders);
                    finalResults.orders[i].attendees = aResults.attendees;
                }
            }
            else
                finalResults.orders = oResults.orders;

            foreach (Order o in finalResults.orders)
                o.attendees = aResults.attendees;
            return finalResults;
        }
        /// <summary>
        /// This returns a list of Attendees, as an 'AttendeeResults,' associated with with the event of the given ID.
        /// </summary>
        /// <param name="eventId"></param>
        /// <returns>AttendeeResults</returns>
        public AttendeeResults GetAttendees(string eventId)
        {
            GetClient();
            var url = string.Format("{0}/events/{1}/attendees/?token={2}", _baseURL, eventId, _token);
            var result = client.DownloadString(url);
            AttendeeResults tempResults = JsonConvert.DeserializeObject<AttendeeResults>(result);
            AttendeeResults finalResults = new AttendeeResults();
            if (tempResults.Pagination.page_count > 1)
            {
                for (int i = 0; i < tempResults.Pagination.page_count; i++)
                {
                    var tUrl = string.Format("{0}/events/{1}/attendees/?token={2}&page={3}", _baseURL, eventId, _token, i + 1);
                    var tResult = client.DownloadString(tUrl);
                    AttendeeResults tResults = JsonConvert.DeserializeObject<AttendeeResults>(tResult);
                    if (finalResults.attendees == null)
                        finalResults.attendees = new List<Attendee>();
                    if (tResults.attendees != null)
                        finalResults.attendees.AddRange(tResults.attendees);
                }
            }
            else
                finalResults.attendees = tempResults.attendees;

            return finalResults;
        }

        private WebClient GetClient()
        {
            if (client == null)
            {
                client = new WebClient();
                return client;
            }
            else return client;
        }
    }
}
