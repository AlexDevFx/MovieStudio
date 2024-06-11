using System.Linq.Expressions;
using MovieStudio.Core.Movies;

namespace MovieStudio.Core.Contracts;

public interface IMoviesRepository
{
    Movie? ById(int id);
    Movie? Create(Movie newMovie);
    Movie? Update(Movie updatedMovie);
    bool Delete(int id);
    bool IsExist(int id, int directorId);
    Task<IEnumerable<Movie>> List(Expression<Func<Movie, bool>> predicate, CancellationToken cancellationToken);
}