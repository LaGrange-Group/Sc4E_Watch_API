
using System;

public class ReverbQueryListings
{
    public int total { get; set; }
    public int current_page { get; set; }
    public int per_page { get; set; }
    public int total_pages { get; set; }
    public _Links _links { get; set; }
    public string humanized_params { get; set; }
    public Listing1[] listings { get; set; }
    public string ships_to { get; set; }
    public string suggestion { get; set; }
}

public class _Links
{
    public Follow follow { get; set; }
    public Suggestion suggestion { get; set; }
    public Listing listing { get; set; }
}

public class Follow
{
    public string href { get; set; }
}

public class Suggestion
{
    public string href { get; set; }
}

public class Listing
{
    public string href { get; set; }
}

public class Listing1
{
    public int id { get; set; }
    public string make { get; set; }
    public string model { get; set; }
    public string finish { get; set; }
    public string year { get; set; }
    public string title { get; set; }
    public DateTime created_at { get; set; }
    public string shop_name { get; set; }
    public Shop shop { get; set; }
    public string description { get; set; }
    public Condition condition { get; set; }
    public Price price { get; set; }
    public Buyer_Price buyer_price { get; set; }
    public Original_Price original_price { get; set; }
    public Ribbon ribbon { get; set; }
    public int inventory { get; set; }
    public bool has_inventory { get; set; }
    public bool offers_enabled { get; set; }
    public Category[] categories { get; set; }
    public string listing_currency { get; set; }
    public DateTime published_at { get; set; }
    public State state { get; set; }
    public bool auction { get; set; }
    public int shop_id { get; set; }
    public Shipping shipping { get; set; }
    public Price_Drop price_drop { get; set; }
    public _Links1 _links { get; set; }
    public Photo1[] photos { get; set; }
}

public class Shop
{
    public string slug { get; set; }
    public bool preferred_seller { get; set; }
}

public class Condition
{
    public string uuid { get; set; }
    public string display_name { get; set; }
    public string slug { get; set; }
}

public class Price
{
    public bool tax_included { get; set; }
    public string amount { get; set; }
    public int amount_cents { get; set; }
    public string currency { get; set; }
    public string symbol { get; set; }
    public string display { get; set; }
}

public class Buyer_Price
{
    public bool tax_included { get; set; }
    public string amount { get; set; }
    public int amount_cents { get; set; }
    public string currency { get; set; }
    public string symbol { get; set; }
    public string display { get; set; }
}

public class Original_Price
{
    public bool tax_included { get; set; }
    public string amount { get; set; }
    public int amount_cents { get; set; }
    public string currency { get; set; }
    public string symbol { get; set; }
    public string display { get; set; }
}

public class Ribbon
{
    public string display { get; set; }
    public string reason { get; set; }
}

public class State
{
    public string slug { get; set; }
    public string description { get; set; }
}

public class Shipping
{
    public bool free_expedited_shipping { get; set; }
    public bool local { get; set; }
    public Rate1[] rates { get; set; }
    public Initial_Offer_Rate initial_offer_rate { get; set; }
}

public class Initial_Offer_Rate
{
    public string region_code { get; set; }
    public Rate rate { get; set; }
}

public class Rate
{
    public Original original { get; set; }
    public Display display { get; set; }
}

public class Original
{
    public string amount { get; set; }
    public int amount_cents { get; set; }
    public string currency { get; set; }
    public string symbol { get; set; }
    public string display { get; set; }
}

public class Display
{
    public string amount { get; set; }
    public int amount_cents { get; set; }
    public string currency { get; set; }
    public string symbol { get; set; }
    public string display { get; set; }
}

public class Rate1
{
    public string region_code { get; set; }
    public Rate2 rate { get; set; }
}

public class Rate2
{
    public string amount { get; set; }
    public int amount_cents { get; set; }
    public string currency { get; set; }
    public string symbol { get; set; }
    public string display { get; set; }
}

public class Price_Drop
{
    public int percent { get; set; }
    public string display { get; set; }
    public Original_Price1 original_price { get; set; }
}

public class Original_Price1
{
    public bool tax_included { get; set; }
    public string amount { get; set; }
    public int amount_cents { get; set; }
    public string currency { get; set; }
    public string symbol { get; set; }
    public string display { get; set; }
}

public class _Links1
{
    public Photo photo { get; set; }
    public Self self { get; set; }
    public Edit edit { get; set; }
    public Web web { get; set; }
    public Make_Offer make_offer { get; set; }
    public Cart cart { get; set; }
    public Watchlist watchlist { get; set; }
}

public class Photo
{
    public string href { get; set; }
}

public class Self
{
    public string href { get; set; }
}

public class Edit
{
    public string href { get; set; }
}

public class Web
{
    public string href { get; set; }
}

public class Make_Offer
{
    public string href { get; set; }
    public string method { get; set; }
}

public class Cart
{
    public string href { get; set; }
}

public class Watchlist
{
    public string href { get; set; }
}

public class Category
{
    public string uuid { get; set; }
    public string full_name { get; set; }
}

public class Photo1
{
    public _Links2 _links { get; set; }
}

public class _Links2
{
    public Large_Crop large_crop { get; set; }
    public Small_Crop small_crop { get; set; }
    public Full full { get; set; }
    public Thumbnail thumbnail { get; set; }
}

public class Large_Crop
{
    public string href { get; set; }
}

public class Small_Crop
{
    public string href { get; set; }
}

public class Full
{
    public string href { get; set; }
}

public class Thumbnail
{
    public string href { get; set; }
}
