using Mapster;

namespace MovieStudio.Core.Movies;

public class EntityMapper: IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<UpdateMovie, Movie>()
            .Map(dest => dest.Title, src => src.Title, src => !string.IsNullOrEmpty(src.Title))
            .Map(dest => dest.Description, src => src.Description, src => !string.IsNullOrEmpty(src.Description))
            .Map(dest => dest.Duration, src => src.Duration, src => src.Duration != null && src.Duration > TimeSpan.Zero)
            .Map(dest => dest.Genres, src => src.Genres, src => src.Genres != null)
            .Map(dest => dest.Started, src => src.StartFilming, src => src.StartFilming != null)
            .Map(dest => dest.Ended, src => src.EndFilming, src => src.EndFilming != null)
            .Map(dest => dest.Budget, src => src.Budget, src => src.Budget != null && src.Budget > 0m);
    }
}