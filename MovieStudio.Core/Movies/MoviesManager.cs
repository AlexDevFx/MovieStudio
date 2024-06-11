using Mapster;
using MovieStudio.Contacts.Movies;
using MovieStudio.Contacts.Users;
using MovieStudio.Core.Contracts;
using MovieStudio.Core.Operations;
using MovieStudio.Core.Users;

namespace MovieStudio.Core.Movies;

public class MoviesManager
{
    private readonly IClockProvider _clockProvider;
    private readonly IMoviesRepository _moviesRepository;
    private readonly MovieOperationsChecker _movieOperationsChecker;
    private readonly IAuthorizedUser _authorizedUser;

    public MoviesManager(IClockProvider clockProvider, 
        IMoviesRepository moviesRepository,
        MovieOperationsChecker movieOperationsChecker,
        IAuthorizedUser authorizedUser)
    {
        _authorizedUser = authorizedUser;
        _movieOperationsChecker = movieOperationsChecker;
        _moviesRepository = moviesRepository;
        _clockProvider = clockProvider;
    }
    
    public Result NewMovie(NewMovie movie)
    {
        string? error = _movieOperationsChecker.CanCreateMovie(movie);
        if (error != null) return new(error);

        _moviesRepository.Create(new Movie(movie.DirectorId, movie.Title, movie.Description, movie.Budget, movie.Genres, movie.Duration,
            movie.StartFilming, movie.EndFilming));
        
        return new();
    }

    public Result DeleteMovie(int movieId)
    {
        var movie = _moviesRepository.ById(movieId);

        string? error = _movieOperationsChecker.CanDeleteMovie(movie);
        if (error != null) return new(error);

        _moviesRepository.Delete(movieId);

        return new();
    }

    public Result UpdateMovie(int movieId, UpdateMovie updatedMovie)
    {
        var movie = _moviesRepository.ById(movieId);

        string? error = _movieOperationsChecker.CanUpdateMovie(movie);
        if (error != null) return new(error);
       
        movie.Adapt(updatedMovie);
        
        return new();
    }
    
    public Result SendOffer(Movie movie, Actor actor)
    {
        string? error = _movieOperationsChecker.CanSendOffer(movie, actor);
        if (error != null) return new(error);
        
        movie.Offers.Add(new MovieOffer(movie, actor, _clockProvider.Now));

        return new();
    }

    public Result StartFilming(Movie movie)
    {
        string? error = _movieOperationsChecker.CanStartFilming(movie, () => _clockProvider.Now);
        if (error != null) return new(error);

        movie.StartFilming(_clockProvider.Now);

        return new();
    }
}