using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using MovieStudio.Core.Contracts;
using MovieStudio.Core.Movies;

namespace MovieStudio.Data;

public partial class MoviesDbContext: IMoviesRepository
{
    public Movie? ById(int id)
    {
        return Movies.FirstOrDefault(e => e.Id == id);
    }

    public Movie? Create(Movie newMovie)
    {
        Movies.Add(newMovie);
        if(SaveChanges() > 0)
            return newMovie;

        return null;
    }

    public Movie? Update(Movie updatedMovie)
    {
        Movies.Update(updatedMovie);
        if(SaveChanges() > 0)
            return updatedMovie;

        return null;
    }

    public bool Delete(int id)
    {
        var firstOrDefault = Movies.FirstOrDefault(e => e.Id == id);
        if (firstOrDefault != null)
        {
            Movies.Remove(firstOrDefault);
            SaveChanges();
        }

        return false;
    }

    public bool IsExist(int id, int directorId)
    {
        return Movies.Any(e => e.Id == id && e.DirectorId == directorId);
    }

    public async Task<IEnumerable<Movie>> List(Expression<Func<Movie, bool>> predicate, CancellationToken cancellationToken)
    {
        return await Movies.Where(predicate).ToListAsync(cancellationToken);
    }
}