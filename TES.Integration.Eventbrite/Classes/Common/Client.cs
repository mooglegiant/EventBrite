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
            foreach (Order o in oResults.orders)
                o.attendees = aResults.attendees;

            return oResults;
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
            return JsonConvert.DeserializeObject<AttendeeResults>(result);
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

        public List<AttendeeAnswer> GetAnswers()
        {
            //I can't figure out how to find the answers...? I don't think they're natively stored with the attendees
            return null;
        }

    }
}
