using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace S4CE_Watch.Helpers
{
    public class HttpClientManager
    {
        public async Task<ReverbQueryListings> GetReverb(string url)
        {
            var httpWebRequest = (HttpWebRequest)WebRequest.Create("https://api.reverb.com/api/listings?query=guild s4ce");
            httpWebRequest.ContentType = "application/hal+json";
            httpWebRequest.Method = "GET";
            httpWebRequest.Accept = "*/*";
            httpWebRequest.Headers.Add("Accept-Version", "3.0");
            httpWebRequest.Headers.Add("Authorization", "Bearer d8b33418027ea3aa8d97bf2e920af8929d50130bdde73fd5512efb8db4224330");

            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();

            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                ReverbQueryListings listings = JsonConvert.DeserializeObject<ReverbQueryListings>(streamReader.ReadToEnd());
                return listings;
            }
        }
    }
}
