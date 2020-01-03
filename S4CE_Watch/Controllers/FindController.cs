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
            ReverbQueryListings listings = await manager.GetReverb("https://api.reverb.com/api/listings?query=guild s4ce");
            List <Listing1> liveListings = listings.listings.Where(l => l.state.description == "Live").ToList();
            foreach(Listing1 listing in liveListings)
            {
                listingCards.Add(new ListingCard()
                {
                    id = listing.id,
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
            return new AllListings() { reverb = listingCards };
        }
    }
}