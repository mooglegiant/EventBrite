using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using TES.Integration.Template.Entities;

namespace TES.Integration.Template.Common
{
    public class Service
    {
        #region Constructor
        public Service(string username, string key)
        {
            _username = username;
            _key = key;
        }
        #endregion

        #region Properties
        public string _username { get; set; }
        public string _key { get; set; }
        #endregion

        #region Variables
        WebClient c;
        #endregion

        #region functions
        private void GetClient()
        {
            if (c == null)
            {
                c = new WebClient();
            }
        }
        public ServiceResult<Customer> GetCustomer(int id){
            GetClient();
            try
            {
                Customer c = new Customer();
                //
                //The real web service call & deserialisation of JSON result to object
                //
                ServiceResult<Customer> r = new ServiceResult<Customer>(true, c, "");
                return r;
            }
            catch (Exception e)
            {
                Customer c = new Customer();
                ServiceResult<Customer> r = new ServiceResult<Customer>(false, c, e.Message);
                return r;
            }
        }
        public ServiceResult<Item> GetItem(int id)
        {
            GetClient();
            Item i = new Item();
            ServiceResult<Item> r = new ServiceResult<Item>(true, i, "");
            return r;
        }
        public ServiceResult<CustomerList> GetCustomers(){
            GetClient();
            CustomerList cl = new CustomerList();
            cl.Add(new Customer { id = 1, name="steve" });
            cl.Add(new Customer { id = 2, name = "jane" });
            ServiceResult<CustomerList> r = new ServiceResult<CustomerList>(true,cl,"");
            return r;
        }
        #endregion
    }
}
