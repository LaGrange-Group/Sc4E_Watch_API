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
        [Route("all")]
        public async Task<IActionResult> All()
        {
            List<ListingCard> reverbListings = new List<ListingCard>();
            List<ListingCard> ebayListings = new List<ListingCard>();
            List<ListingCard> craigslistListings = new List<ListingCard>();
            AllListings allListings = new AllListings();
            try
            {
                reverbListings = Reverb();
            }
            catch(Exception e)
            {

            }
            try
            {
                ebayListings = await Ebay();
            }
            catch (Exception e)
            {
                
            }
            try
            {
                craigslistListings = await Craigslist();
            }
            catch (Exception e)
            {

            }
            
            if (reverbListings != null && reverbListings.Count > 0)
            {
                allListings.listings = reverbListings;
            }
            if (ebayListings != null && ebayListings.Count > 0)
            {
                foreach(ListingCard listing in ebayListings)
                {
                    allListings.listings.Add(listing);
                }
            }
            if (craigslistListings != null && craigslistListings.Count > 0)
            {
                foreach (ListingCard listing in craigslistListings)
                {
                    allListings.listings.Add(listing);
                }
            }
            return Ok(allListings);
        }

        private List<ListingCard> Reverb()
        {
            List<ListingCard> listingCards = new List<ListingCard>();
            List<Listing1> liveListings = manager.GetReverb("https://api.reverb.com/api/listings?query=guild s4ce");
            foreach (Listing1 listing in liveListings)
            {
                listingCards.Add(new ListingCard()
                {
                    id = listing.id.ToString(),
                    title = listing.title,
                    description = listing.description,
                    condition = listing.condition.display_name,
                    price = listing.price.amount,
                    published_at = listing.published_at,
                    photo = listing.photos.Select(p => p._links.large_crop.href).FirstOrDefault(),
                    listingLink = "https://reverb.com/item/" + listing.id.ToString(),
                    resourcePhoto = "reverb.png"
                });
            }
            return listingCards;
        }

  
        private async Task<List<ListingCard>> Ebay()
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
                        title = item.Title,
                        description = item.Description.Length > 50 ? item.Description.Substring(0, 50) : item.Description,
                        condition = item.ConditionDisplayName,
                        price = item.ConvertedCurrentPrice.Value.ToString() ?? "UNKOWN",
                        published_at = DateTime.Now,
                        photo = item.PictureURL.ToList().FirstOrDefault(),
                        listingLink = item.ViewItemURLForNaturalSearch,
                        resourcePhoto = "ebay.png"
                    }); ;
                }
            }
            return listingCards;
        }

        private async Task<List<ListingCard>> Craigslist()
        {
            List<ListingCard> listingCards = new List<ListingCard>();
            List<CraigslistListing> listings = await manager.GetCraigslist();
            if (listings != null)
            {
                foreach(CraigslistListing listing in listings)
                {
                    listingCards.Add(new ListingCard()
                    {
                        id = listing.id,
                        title = listing.title,
                        description = "",
                        condition = "",
                        price = listing.price,
                        published_at = DateTime.Parse(listing.post_date),
                        photo = listing.photo,
                        listingLink = listing.link,
                        resourcePhoto = "craigslist.png"
                    });
                }
            }
            return listingCards;
        }
    }
}