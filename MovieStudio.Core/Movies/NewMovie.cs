using MovieStudio.Core.Movies;

namespace MovieStudio.Core;

public record NewMovie(int DirectorId, string Title, string Description, decimal Budget, MovieGenre[] Genres, TimeSpan Duration, DateTime StartFilming, DateTime EndFilming)
{
    public IEnumerable<string> Validate()
    {
        if (Duration <= TimeSpan.Zero)
        {
            yield return "Duration can not be zero or less";
        }

        if (StartFilming >= EndFilming)
        {
            yield return "Filming start and end time dates are incorrect";
        }

        if (Budget <= 0m)
        {
            yield return "You can not create movie with empty budget";
        }
    }
}