using System.Collections.ObjectModel;
using MovieStudio.Core.Movies;

namespace MovieStudio.Core.Users;

public class Actor
{
    public int Id { get; set; }
    public int UserId { get; private set; }
    public Address Address { get; private set; }
    public decimal Compensation { get; private set; }
    
    public Collection<Movie> Movies { get; private set; }
    
    public Collection<MovieOffer> Offers { get; private set; }
}