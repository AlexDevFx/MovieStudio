using MovieStudio.Core.Operations;
using MovieStudio.Core.Users;

namespace MovieStudio.Core.Movies;

public class MovieOffer
{
    public MovieOffer(Movie movie, Actor actor, DateTime sendTime)
    {
        Movie = movie;
        Actor = actor;
        Sent = sendTime;
    }

    public OfferStatus Status { get; private set; }
    public Movie Movie { get; private set; }
    public Actor Actor { get; private set; }
    public DateTime Sent { get; private set; }
    public DateTime Updated { get; private set; }

    public Result Approve(DateTime time)
    {
        return ChangeStatus(OfferStatus.Accepted, time);
    }

    public Result Decline(DateTime time)
    {
        return ChangeStatus(OfferStatus.Accepted, time);
    }

    public Result Accept(DateTime time)
    {
        return ChangeStatus(OfferStatus.Accepted, time);
    }

    public Result Receive(DateTime time)
    {
        return ChangeStatus(OfferStatus.Accepted, time);
    }

    private Result ChangeStatus(OfferStatus newStatus, DateTime time)
    {
        var statusCheckingResult = CheckStatus(newStatus);
        if (statusCheckingResult != null) return statusCheckingResult;
        
        Status = newStatus;
        Updated = time;

        return new();
    }

    private Result? CheckStatus(OfferStatus newStatus)
    {
        if(OfferStatusChangesAllowance.Forbidden.TryGetValue(Status, out var forbidden)
           && forbidden.Contains(newStatus))
        {
            return new($"You can not changed status");
        }

        return null;
    }
}