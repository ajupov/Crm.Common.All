namespace Crm.Common.All.Types.AttributeType
{
    public enum AttributeType : byte
    {
        Tag = 1,
        Bool = 2,
        Integer = 6,
        Long = 8,
        Decimal = 10,
        Double = 12,
        Date = 20,
        Time = 21,
        DateTime = 22,
        ListOf = 23,
        Email = 30,
        Phone = 31,
        Address = 32,
        Geolocation = 33,
        Image = 34,
        Document = 35,
        Link = 36,
        SocialLink = 37,
        ImageLink = 38,
        DocumentLink = 39,
        BankAccount = 40,
        Formula = 50,
        Json = 60,
        Xml = 61,
        Html = 63,
        Text = 64
    }
}
