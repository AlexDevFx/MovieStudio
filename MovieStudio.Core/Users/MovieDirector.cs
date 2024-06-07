using MovieStudio.Core.Movies;

namespace MovieStudio.Core.Users;

public class MovieDirector
{
    public int Id { get; set; }
    public User User { get; private set; }
    public ICollection<Movie> Movies { get; private set; }
}