using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Configuration;
using System.Net.Http.Formatting;


namespace ZoomCarRentalProject.Repository
{
    public class ServicesRepository
    {
        public HttpClient client { get; set; }

        public ServicesRepository()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri(ConfigurationManager.AppSettings["Servicesurl"].ToString());
        }

        public HttpResponseMessage GetResponse(string url)
        {
            return client.GetAsync(url).Result;
        }

        public HttpResponseMessage PostResponse(string url,object model)
        {
            return client.PostAsJsonAsync(url, model).Result;
        }

        public HttpResponseMessage PutResponse(string url, object model)
        {
            return client.PutAsJsonAsync(url, model).Result;
        }

        public HttpResponseMessage DeleteResponse(string url)
        {
            return client.DeleteAsync(url).Result;
        }
    }
}