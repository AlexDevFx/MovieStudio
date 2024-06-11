namespace MovieStudio.Core.Movies;

public record Filter(int? directorId = null, int? AppovedActorId = null, int? AcceptedActorId = null, decimal? Budget = null, DateTime? Started = null, DateTime? Ended = null, int? GenreId = null)
{
    public int? DirectorId { get; internal set; } = directorId;
}