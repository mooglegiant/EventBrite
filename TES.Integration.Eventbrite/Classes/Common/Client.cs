using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using Newtonsoft.Json;
using TES.Integration.Eventbrite.Classes.Events;
using TES.Integration.Eventbrite.Classes.AttendeeObjects;
using TES.Integration.Template.Common;

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
        public ServiceResult<EventsResults> GetEvents()
        {
            try
            {
                GetClient();
                var url = string.Format("{0}/users/{1}/events/?token={2}", _baseURL, _eb_user, _token);
                var result = client.DownloadString(url);
                var tempResults = new ServiceResult<EventsResults>(true, JsonConvert.DeserializeObject<EventsResults>(result), "");
                var finalResults = new EventsResults();

                if (tempResults.Data.Pagination.page_count > 1)
                {
                    for (int i = 0; i < tempResults.Data.Pagination.page_count; i++)
                    {
                        var tUrl = string.Format("{0}/users/{1}/events/?token={2}&page={3}", _baseURL, _eb_user, _token, i + 1);
                        var tResult = client.DownloadString(tUrl);
                        var tResults = new ServiceResult<EventsResults>(true, JsonConvert.DeserializeObject<EventsResults>(result), "");
                        if (finalResults.events == null)
                            finalResults.events = new List<Event>();
                        if (tResults.Data.events != null)
                            finalResults.events.AddRange(tResults.Data.events);
                    }
                }
                else
                    finalResults.events = tempResults.Data.events;

                return new ServiceResult<EventsResults>(true, finalResults, "");
            }
            catch (Exception e)
            {
                GetClient();
                return new ServiceResult<EventsResults>(false, new EventsResults(), e.Message);
            }
        }
        /// <summary>
        /// This function returns every Event associated with an account as an 'EventsResults' and truncates the descriptions to the given length.
        /// </summary>
        /// <returns>EventsResults</returns>
        public ServiceResult<EventsResults> GetEvents(int length)
        {
            try
            {
                GetClient();
                var url = string.Format("{0}/users/{1}/events/?token={2}", _baseURL, _eb_user, _token);
                var result = client.DownloadString(url);
                var tempResults = new ServiceResult<EventsResults>(true, JsonConvert.DeserializeObject<EventsResults>(result), "");
                var finalResults = new EventsResults();

                if (tempResults.Data.Pagination.page_count > 1)
                {
                    for (int i = 0; i < tempResults.Data.Pagination.page_count; i++)
                    {
                        var tUrl = string.Format("{0}/users/{1}/events/?token={2}&page={3}", _baseURL, _eb_user, _token, i + 1);
                        var tResult = client.DownloadString(tUrl);
                        var tResults = new ServiceResult<EventsResults>(true, JsonConvert.DeserializeObject<EventsResults>(result), "");
                        if (finalResults.events == null)
                            finalResults.events = new List<Event>();
                        if (tResults.Data.events != null)
                            finalResults.events.AddRange(tResults.Data.events);
                    }
                }
                else
                    finalResults.events = tempResults.Data.events;
                foreach (Event e in finalResults.events)
                {
                    e.description.text = Truncate(e.description.text, length);
                }
                return new ServiceResult<EventsResults>(true, finalResults, "");
            }
            catch (Exception e)
            {
                GetClient();
                return new ServiceResult<EventsResults>(false, new EventsResults(), e.Message);
            }
        }
        /// <summary>
        /// This function returns a single Event, as dictated by the eventId given.
        /// </summary>
        /// <param name="eventId"></param>
        /// <returns>Event</returns>
        public ServiceResult<Event> GetEvent(string eventId)
        {
            try
            {
                GetClient();
                var url = string.Format("{0}/events/{1}/?token={2}", _baseURL, eventId, _token);
                var result = client.DownloadString(url);
                return new ServiceResult<Event>(true, JsonConvert.DeserializeObject<Event>(result), "");
            }
            catch (Exception e)
            {
                GetClient();
                return new ServiceResult<Event>(false, new Event(), e.Message);
            }
        }
        /// <summary>
        /// This function returns a single Event, as dictated by the eventId given, and with strings clipped to the specified length.
        /// </summary>
        /// <param name="eventId"></param>
        /// <returns>Event</returns>
        public ServiceResult<Event> GetEvent(string eventId, int length)
        {
            try
            {
                GetClient();
                var url = string.Format("{0}/events/{1}/?token={2}", _baseURL, eventId, _token);
                var result = client.DownloadString(url);
                ServiceResult<Event> events = new ServiceResult<Event>(true, JsonConvert.DeserializeObject<Event>(result), "");
                events.Data.description.text = Truncate(events.Data.description.text, length);
                return events;
            }
            catch (Exception e)
            {
                GetClient();
                return new ServiceResult<Event>(false, new Event(), e.Message);
            }
        }
        /// <summary>
        /// This returns a list of Orders, as an 'OrderResults,' associated with the event of the given ID.
        /// </summary>
        /// <param name="eventId"></param>
        /// <returns>OrderResults</returns>
        public ServiceResult<OrderResults> GetOrders(string eventId)
        {
            try
            {
                GetClient();
                var url = string.Format("{0}/events/{1}/orders/?token={2}&expand=attendees", _baseURL, eventId, _token);
                var result = client.DownloadString(url);
                OrderResults oResults = JsonConvert.DeserializeObject<OrderResults>(result);
                //ServiceResult<AttendeeResults> aResults = GetAttendees(eventId);
                OrderResults finalResults = new OrderResults();
                finalResults.Pagination = oResults.Pagination;
                if (oResults.Pagination.page_count > 1)
                {
                    for (int i = 0; i < oResults.Pagination.page_count; i++)
                    {
                        var tUrl = string.Format("{0}/events/{1}/orders/?token={2}&page={3}&expand=attendees", _baseURL, eventId, _token, i + 1);
                        var tResult = client.DownloadString(tUrl);
                        OrderResults tResults = JsonConvert.DeserializeObject<OrderResults>(tResult);
                        if (finalResults.orders == null)
                            finalResults.orders = new List<Order>();
                        if (tResults.orders != null)
                            finalResults.orders.AddRange(tResults.orders);
                        //finalResults.orders[i].attendees = aResults.Data.attendees;
                    }
                }
                else
                    finalResults.orders = oResults.orders;

                //foreach (Order o in finalResults.orders)
                    //o.attendees = aResults.Data.attendees;
                return new ServiceResult<OrderResults>(true, finalResults, "");
            }
            catch (Exception e)
            {
                GetClient();
                return new ServiceResult<OrderResults>(false, new OrderResults(), e.Message);
            }
        }
        /// <summary>
        /// This returns a list of Attendees, as an 'AttendeeResults,' associated with with the event of the given ID.
        /// </summary>
        /// <param name="eventId"></param>
        /// <returns>AttendeeResults</returns>
        public ServiceResult<AttendeeResults> GetAttendees(string orderId)
        {
            try
            {
                GetClient();
                var url = string.Format("{0}/events/{1}/attendees/?token={2}", _baseURL, orderId, _token);
                var result = client.DownloadString(url);
                AttendeeResults tempResults = JsonConvert.DeserializeObject<AttendeeResults>(result);
                AttendeeResults finalResults = new AttendeeResults();
                if (tempResults.Pagination.page_count > 1)
                {
                    for (int i = 0; i < tempResults.Pagination.page_count; i++)
                    {
                        var tUrl = string.Format("{0}/events/{1}/attendees/?token={2}&page={3}", _baseURL, orderId, _token, i + 1);
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

                return new ServiceResult<AttendeeResults>(true, finalResults, "");
            }
            catch (Exception e)
            {
                GetClient();
                return new ServiceResult<AttendeeResults>(false, new AttendeeResults(), e.Message);
            }
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

        private string Truncate(string value, int maxLength)
        {
            if (string.IsNullOrEmpty(value)) return value;
            return value.Length <= maxLength ? value : value.Substring(0, maxLength);
        }
    }
}
