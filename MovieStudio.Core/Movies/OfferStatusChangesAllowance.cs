namespace MovieStudio.Core.Movies;

public static class OfferStatusChangesAllowance
{
    public static Dictionary<OfferStatus, OfferStatus[]> Forbidden = new()
    {
        { OfferStatus.Approved, new[] { OfferStatus.Approved, OfferStatus.Declined } },
        { OfferStatus.Accepted, new[] { OfferStatus.Accepted, OfferStatus.Approved, OfferStatus.Declined }},
        { OfferStatus.Declined, new [] { OfferStatus.Declined, OfferStatus.Approved }},
        { OfferStatus.Received, new [] { OfferStatus.Received, OfferStatus.Approved, OfferStatus.Accepted, OfferStatus.Declined }},
        { OfferStatus.Sent, new[] { OfferStatus.Sent, OfferStatus.Received } }
    };
}