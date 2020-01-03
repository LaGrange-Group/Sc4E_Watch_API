using System;

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

