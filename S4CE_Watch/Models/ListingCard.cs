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
        public string title { get; set; }
        public string description { get; set; }
        public string condition { get; set; }
        public string price { get; set; }
        public DateTime published_at { get; set; }
        public string photo { get; set; }
        public string listingLink { get; set; }
        public string resourcePhoto { get; set; }
    }
}
