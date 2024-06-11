using System.Linq.Expressions;
using Mapster;
using MovieStudio.Contacts.Movies;
using MovieStudio.Core.Contracts;
using MovieStudio.Core.Operations;
using MovieStudio.Core.Users;

namespace MovieStudio.Core.Movies;

public class MoviesProvider
{
    private readonly MovieOperationsChecker _movieOperationsChecker;
    private readonly IMoviesRepository _moviesRepository;

    public MoviesProvider(MovieOperationsChecker movieOperationsChecker,
        IMoviesRepository moviesRepository)
    {
        _moviesRepository = moviesRepository;
        _movieOperationsChecker = movieOperationsChecker;
    }
    
    public async Task<(Result result, IEnumerable<DirectorMovieDto> data)> Director(Filter filter, CancellationToken cancellationToken)
    {
        filter.DirectorId = filter.DirectorId.Value;
        
        return await Query<DirectorMovieDto>(filter, cancellationToken);
    }
    
    public async Task<(Result result, IEnumerable<MovieDto> data)> Actor(Filter filter, CancellationToken cancellationToken)
    {
        return await Query<MovieDto>(filter, cancellationToken);
    }
    
    public async Task<(Result result, IEnumerable<MovieDto> data)> Admin(Filter filter, CancellationToken cancellationToken)
    {
        return await Query<MovieDto>(filter, cancellationToken);
    }

    private async Task<(Result result, IEnumerable<T> data)> Query<T>(Filter filter, 
        CancellationToken cancellationToken)
    {
        string? error = _movieOperationsChecker.ReadMoviesList();
        if (error != null) return (new (error), Enumerable.Empty<T>());

        var movies = (await _moviesRepository.List(MoviesSpecifications.ComplexFilter(filter), cancellationToken))
            .Adapt<List<T>>();

        return (new(), movies);
    }
}