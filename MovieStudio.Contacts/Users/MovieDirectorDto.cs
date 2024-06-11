using MovieStudio.Contacts.Movies;

namespace MovieStudio.Contacts.Users;

public class MovieDirectorDto
{
    public int Id { get; set; }
    public UserDto User { get; set; }
    public ICollection<MovieDto> Movies { get; set; }
}