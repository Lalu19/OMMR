using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace AdminClient.Model.Utility
{
    public class HttpWebClients : IHttpWebClients
    {
        public IConfiguration _Iconfiguration { get; set; }
        public HttpWebClients(IConfiguration iconfiguration)
        {
            _Iconfiguration = iconfiguration;
        }
        public string PostRequest(string URI, string parameterValues, bool isAnonymous)
        {
            string jsonString = null;

            string BaseURI = _Iconfiguration["WebAPIBaseUrl"];
            string URL = BaseURI + URI;
            using (var client = new HttpClient())
            {

                client.BaseAddress = new Uri(URL);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                client.Timeout = TimeSpan.FromMinutes(20);
                //GET Method  
                HttpContent c = new StringContent(parameterValues, Encoding.UTF8, "application/json");
                HttpResponseMessage response = client.PostAsync(URL, c).Result;
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {

                    jsonString = response.Content.ReadAsStringAsync()
                                                   .Result
                                                   //.Replace("\\", "")
                                                   //.Replace("\r\n", "'")
                                                   .Trim(new char[1] { '"' });
                }

                return jsonString;
            }

        }

    }
}
