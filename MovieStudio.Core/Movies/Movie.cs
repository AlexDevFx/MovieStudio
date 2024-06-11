using System.Collections.ObjectModel;
using MovieStudio.Contacts;
using MovieStudio.Core.Users;

namespace MovieStudio.Core.Movies;

public class Movie: IHasUpdateTime
{
    public Movie(int directorId, string title, string description, decimal budget, int[] genres, TimeSpan duration, DateTime startFilming, DateTime endFilming)
    {
        DirectorId = directorId;
        Title = title;
        Description = description;
        Budget = budget;
        Genres = genres.Select(e => new MovieGenre
        {
            Movie = this,
            GenreId = e
        }).ToList();
        Duration = duration;
        Started = startFilming;
        Ended = endFilming;
    }

    public int Id { get; private set; }
    public string Title { get; private set; }
    public string Description { get; private set; }
    public decimal Budget { get; private set; }
    public TimeSpan Duration { get; private set;}
    public DateTime Started { get; private set; }
    public DateTime Ended { get; private set; }
    
    public MovieStatus Status { get; private set; }
    
    public Collection<MovieOffer> Offers { get; private set; }
    
    public ICollection<MovieGenre> Genres { get; private set; }
    
    public DateTime? Updated { get; set; }
    
    public int DirectorId { get; set; }
    public Director Director { get; private set; }

    public IEnumerable<Actor> ApprovedActors => Offers.Where(e => e.Status == OfferStatus.Approved).Select(e => e.Actor).ToList();
    public decimal TotalSpentForCompensations => ApprovedActors.Sum(e => e.Compensation);

    public IEnumerable<MovieOffer> AcceptedOffers => Offers.Where(e => e.Status == OfferStatus.Accepted);

    public IEnumerable<MovieOffer> SentOffers =>
        Offers.Where(e => e.Status == OfferStatus.Sent || e.Status == OfferStatus.Received);

    public void StartFilming(DateTime time)
    {
        Status = MovieStatus.InProgress;
        Started = time;
        Updated = time;
    }
    
    public void StopFilming(DateTime time)
    {
        Status = MovieStatus.Filmed;
        Ended = time;
        Updated = time;
    }
}