using System.Collections.ObjectModel;
using MovieStudio.Contacts;

namespace MovieStudio.Core.Movies;

public class Genre: IHasUpdateTime
{
    public int Id { get; private set; }
    public string Name { get; private set; }
    public DateTime? Updated { get; set; }
    public Collection<MovieGenre>? Movies { get; set; }
}