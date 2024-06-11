using MovieStudio.Contacts.Users;
using MovieStudio.Core.Movies;

namespace MovieStudio.Contacts.Movies;

public class DirectorMovieDto: MovieDto
{
    public MovieStatus Status { get; set; }
    
    public ICollection<GenreDto> Genres { get; set; }
    
    public DateTime? Updated { get; set; }
    
    public int DirectorId { get; set; }

    public IEnumerable<ActorDto> ApprovedActors { get; set; }
    
    public decimal TotalSpentForCompensations { get; set; }

    public IEnumerable<MovieOfferDto> AcceptedOffers { get; set; }

    public IEnumerable<MovieOfferDto> SentOffers { get; set; }
}