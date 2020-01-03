using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using S4CE_Watch.Helpers;
using S4CE_Watch.Models;
using Newtonsoft.Json;

namespace S4CE_Watch.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FindController : ControllerBase
    {
        HttpClientManager manager;

        public FindController()
        {
            manager = new HttpClientManager();
        }
        [HttpGet]
        [Route("reverb")]
        public async Task<AllListings> Reverb()
        {
            List<ListingCard> listingCards = new List<ListingCard>();
            ReverbQueryListings reverbListings = await manager.GetReverb("https://api.reverb.com/api/listings?query=guild s4ce");
            List<Listing1> liveListings = reverbListings.listings.Where(l => l.state.description == "Live").ToList();
            foreach (Listing1 listing in liveListings)
            {
                listingCards.Add(new ListingCard()
                {
                    id = listing.id.ToString(),
                    make = listing.make,
                    model = listing.model,
                    finish = listing.finish,
                    year = listing.year,
                    title = listing.title,
                    created_at = listing.created_at,
                    description = listing.description,
                    condition = listing.condition.display_name,
                    price = listing.price.amount,
                    published_at = listing.published_at,
                    state = listing.state.description,
                    photos = listing.photos.Select(p => p._links.large_crop.href).ToList(),
                    listingLink = "https://reverb.com/item/" + listing.id.ToString()
                });
            }
            return new AllListings() { listings = listingCards };
        }

        [HttpGet]
        [Route("ebay")]
        public async Task<AllListings> Ebay()
        {
            List<ListingCard> listingCards = new List<ListingCard>();
            List<EbayItem> listings = await manager.GetEbay();
            if (listings != null)
            {
                foreach (EbayItem item in listings)
                {
                    listingCards.Add(new ListingCard()
                    {
                        id = item.ItemID,
                        make = item.ItemSpecifics.NameValueList.Where(n => n.Name == "Brand").SingleOrDefault()?.Value?[0] ?? "?Guild",
                        model = item.ItemSpecifics.NameValueList.Where(n => n.Name == "Model").SingleOrDefault()?.Value?[0] ?? "?Songbird",
                        finish = item.ItemSpecifics.NameValueList.Where(n => n.Name == "Body Material").SingleOrDefault()?.Value?[0] ?? "?Natural",
                        year = item.ItemSpecifics.NameValueList.Where(n => n.Name == "Model Year").SingleOrDefault()?.Value?[0] ?? "???",
                        title = item.Title,
                        created_at = DateTime.Now,
                        description = item.Description,
                        condition = item.ConditionDisplayName,
                        price = item.ConvertedCurrentPrice.Value.ToString() ?? "???",
                        published_at = DateTime.Now,
                        state = "Live",
                        photos = item.PictureURL.ToList(),
                        listingLink = item.ViewItemURLForNaturalSearch
                    }); ;
                }
            }
            return new AllListings() { listings = listingCards };
        }

    }
}