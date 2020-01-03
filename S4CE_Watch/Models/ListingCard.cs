using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace S4CE_Watch.Models
{

    public class AllListings
    {
        public List<ListingCard> listings { get; set; }

    }

    public class ListingCard
    {
        public string id { get; set; }
        public string make { get; set; }
        public string model { get; set; }
        public string finish { get; set; }
        public string year { get; set; }
        public string title { get; set; }
        public DateTime created_at { get; set; }
        public string description { get; set; }
        public string condition { get; set; }
        public string price { get; set; }
        public DateTime published_at { get; set; }
        public string state { get; set; }
        public List<string> photos { get; set; }
        public string listingLink { get; set; }
    }
}
