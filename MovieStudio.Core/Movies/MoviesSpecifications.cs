using System.Linq.Expressions;

namespace MovieStudio.Core.Movies;

public static class MoviesSpecifications
{
    public static Expression<Func<Movie, bool>> FilterByGenre(int id) => m => m.Genres.Any(g => g.Id == id);

    public static Expression<Func<Movie, bool>> FilterByBudget(decimal budget) =>
        m => Math.Abs(m.Budget - budget) <= 0.001m;
    
    public static Expression FilterByDates(DateTime? start, DateTime? end)
    {
        
        Expression<Func<Movie, bool>> predicate = _ => true;
        var fullExpression = predicate.Body;
        
        if (start.HasValue)
        {
            Expression<Func<Movie, bool>> startDateExpression = m => m.Started >= start;
            fullExpression = Expression.AndAlso(predicate, startDateExpression);
        }

        return fullExpression;
    }
}