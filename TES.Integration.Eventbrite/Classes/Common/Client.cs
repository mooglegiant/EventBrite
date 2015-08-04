using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using Newtonsoft.Json;
using TES.Integration.Eventbrite.Classes.Events;

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
        public EventsResults GetEvents()
        {
            GetClient();
            var url = string.Format("{0}/users/{1}/events/?token={2}", _baseURL, _eb_user, _token);
            var result = client.DownloadString(url);
            return JsonConvert.DeserializeObject<EventsResults>(result);
        }
        public


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
