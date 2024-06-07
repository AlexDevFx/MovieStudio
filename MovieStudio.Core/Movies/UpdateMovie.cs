namespace MovieStudio.Core.Movies;

public record UpdateMovie(string? Title, string? Description, decimal? Budget, Genre[]? Genres, TimeSpan? Duration, DateTime? StartFilming, DateTime? EndFilming);