using System;

public class EbayListings
{
    public Finditemsbykeywordsresponse[] findItemsByKeywordsResponse { get; set; }
}

public class Finditemsbykeywordsresponse
{
    public string[] ack { get; set; }
    public string[] version { get; set; }
    public DateTime[] timestamp { get; set; }
    public Searchresult[] searchResult { get; set; }
    public Paginationoutput[] paginationOutput { get; set; }
    public string[] itemSearchURL { get; set; }
}

public class Searchresult
{
    public string count { get; set; }
    public EbayListingItem[] item { get; set; }
}

public class EbayListingItem
{
    public string[] itemId { get; set; }
    public string[] title { get; set; }
    public string[] globalId { get; set; }
    public Primarycategory[] primaryCategory { get; set; }
    public string[] galleryURL { get; set; }
    public string[] viewItemURL { get; set; }
    public string[] paymentMethod { get; set; }
    public string[] autoPay { get; set; }
    public string[] postalCode { get; set; }
    public string[] location { get; set; }
    public string[] country { get; set; }
    public Shippinginfo[] shippingInfo { get; set; }
    public Sellingstatu[] sellingStatus { get; set; }
    public Listinginfo[] listingInfo { get; set; }
    public string[] returnsAccepted { get; set; }
    public string[] galleryPlusPictureURL { get; set; }
    public EbayListingCondition[] condition { get; set; }
    public string[] isMultiVariationListing { get; set; }
    public string[] topRatedListing { get; set; }
}

public class Primarycategory
{
    public string[] categoryId { get; set; }
    public string[] categoryName { get; set; }
}

public class Shippinginfo
{
    public Shippingservicecost[] shippingServiceCost { get; set; }
    public string[] shippingType { get; set; }
    public string[] shipToLocations { get; set; }
    public string[] expeditedShipping { get; set; }
    public string[] oneDayShippingAvailable { get; set; }
    public string[] handlingTime { get; set; }
}

public class Shippingservicecost
{
    public string currencyId { get; set; }
    public string __value__ { get; set; }
}

public class Sellingstatu
{
    public Currentprice[] currentPrice { get; set; }
    public Convertedcurrentprice[] convertedCurrentPrice { get; set; }
    public string[] bidCount { get; set; }
    public string[] sellingState { get; set; }
    public string[] timeLeft { get; set; }
}

public class Currentprice
{
    public string currencyId { get; set; }
    public string __value__ { get; set; }
}

public class Convertedcurrentprice
{
    public string currencyId { get; set; }
    public string __value__ { get; set; }
}

public class Listinginfo
{
    public string[] bestOfferEnabled { get; set; }
    public string[] buyItNowAvailable { get; set; }
    public DateTime[] startTime { get; set; }
    public DateTime[] endTime { get; set; }
    public string[] listingType { get; set; }
    public string[] gift { get; set; }
    public string[] watchCount { get; set; }
}

public class EbayListingCondition
{
    public string[] conditionId { get; set; }
    public string[] conditionDisplayName { get; set; }
}

public class Paginationoutput
{
    public string[] pageNumber { get; set; }
    public string[] entriesPerPage { get; set; }
    public string[] totalPages { get; set; }
    public string[] totalEntries { get; set; }
}

public class EbayItemResult
{
    public DateTime Timestamp { get; set; }
    public string Ack { get; set; }
    public string Build { get; set; }
    public string Version { get; set; }
    public EbayItem Item { get; set; }
}

public class EbayItem
{
    public string Description { get; set; }
    public string ItemID { get; set; }
    public DateTime EndTime { get; set; }
    public string ViewItemURLForNaturalSearch { get; set; }
    public string ListingType { get; set; }
    public string Location { get; set; }
    public string GalleryURL { get; set; }
    public string[] PictureURL { get; set; }
    public string PrimaryCategoryID { get; set; }
    public string PrimaryCategoryName { get; set; }
    public int BidCount { get; set; }
    public EbayItemConvertedcurrentprice ConvertedCurrentPrice { get; set; }
    public string ListingStatus { get; set; }
    public string TimeLeft { get; set; }
    public string Title { get; set; }
    public Itemspecifics ItemSpecifics { get; set; }
    public string Country { get; set; }
    public bool AutoPay { get; set; }
    public int ConditionID { get; set; }
    public string ConditionDisplayName { get; set; }
    public string ConditionDescription { get; set; }
}

public class EbayItemConvertedcurrentprice
{
    public float Value { get; set; }
    public string CurrencyID { get; set; }
}

public class Itemspecifics
{
    public Namevaluelist[] NameValueList { get; set; }
}

public class Namevaluelist
{
    public string Name { get; set; }
    public string[] Value { get; set; }
}