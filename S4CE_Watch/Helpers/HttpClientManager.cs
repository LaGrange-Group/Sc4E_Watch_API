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

        public async Task<List<EbayItem>> GetEbay()
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage listingResponse = await client.GetAsync("https://svcs.ebay.com/services/search/FindingService/v1?OPERATION-NAME=findItemsByKeywords&SERVICE-NAME=FindingService&SERVICE-VERSION=1.13.0&SECURITY-APPNAME=&RESPONSE-DATA-FORMAT=JSON&REST-PAYLOAD&keywords=%22guild+songbird%22");
            if (listingResponse.IsSuccessStatusCode)
            {
                List<EbayItem> items = new List<EbayItem>();
                EbayListings ebay = JsonConvert.DeserializeObject<EbayListings>(await listingResponse.Content.ReadAsStringAsync());
                List<EbayListingItem> listingItems = ebay.findItemsByKeywordsResponse[0].searchResult[0].item.Where(i => i.primaryCategory[0].categoryId.Contains("33034") || i.primaryCategory[0].categoryId.Contains("22966") || i.primaryCategory[0].categoryId.Contains("619") || i.primaryCategory[0].categoryId.Contains("33021") || i.primaryCategory[0].categoryId.Contains("165255")).ToList();
                foreach(EbayListingItem item in listingItems)
                {
                    string url = $"https://open.api.ebay.com/shopping?callname=GetSingleItem&responseencoding=JSON&appid=&siteid=0&version=967&ItemID={item.itemId[0]}&IncludeSelector=Description,ItemSpecifics";
                    HttpResponseMessage itemResponse = await client.GetAsync(url);
                    if (itemResponse.IsSuccessStatusCode)
                    {
                        EbayItemResult ebayItem = JsonConvert.DeserializeObject<EbayItemResult>(await itemResponse.Content.ReadAsStringAsync());
                        if (item != null)
                        {
                            items.Add(ebayItem.Item);
                        }
                    }
                }
                return items.Count > 0 ? items : null;
            }
            return null;
        }
    }
}
