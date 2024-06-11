using System.Linq.Expressions;

namespace MovieStudio.Core.Movies;

public static class MoviesSpecifications
{
    public static Expression<Func<Movie, bool>> ComplexFilter(Filter filter)
    {
        Expression<Func<Movie, bool>> predicate = _ => true;
        var fullExpression = predicate.Body;
        
        if (filter.DirectorId.HasValue)
        {
            fullExpression = Expression.And(predicate, ByDirector(filter.DirectorId.Value));
        }
        
        if (filter.AcceptedActorId.HasValue)
        {
            fullExpression = Expression.And(predicate, ByAcceptedActor(filter.AcceptedActorId.Value));
        }

        if (filter.GenreId.HasValue)
        {
            fullExpression = Expression.And(predicate, ByGenre(filter.GenreId.Value));
        }
        
        if (filter.Budget.HasValue)
        {
            fullExpression = Expression.And(predicate, ByBudget(filter.Budget.Value));
        }
        
        fullExpression = Expression.And(predicate, ByDates(filter.Started, filter.Ended));
        
        if (filter.GenreId.HasValue)
        {
            fullExpression = Expression.And(predicate, ByGenre(filter.GenreId.Value));
        }
        
        return fullExpression as Expression<Func<Movie, bool>>;
    }
    public static Expression<Func<Movie, bool>> ByGenre(int id) => m => m.Genres.Any(g => g.GenreId == id);

    public static Expression<Func<Movie, bool>> ByBudget(decimal budget) =>
        m => Math.Abs(m.Budget - budget) <= 0.001m;
    
    public static Expression ByDates(DateTime? start, DateTime? end)
    {
        Expression<Func<Movie, bool>> predicate = _ => true;
        var fullExpression = predicate.Body;
        
        if (start.HasValue)
        {
            Expression<Func<Movie, bool>> startDateExpression = m => m.Started >= start;
            fullExpression = Expression.AndAlso(predicate, startDateExpression);
        }

        if (end.HasValue)
        {
            Expression<Func<Movie, bool>> endDateExpression = m => m.Ended <= end;
            fullExpression = Expression.AndAlso(predicate, endDateExpression);
        }

        return fullExpression;
    }

    public static Expression<Func<Movie, bool>> ByDirector(int directorId) => m => m.DirectorId == directorId;

    public static Expression<Func<Movie, bool>> ByParticaptedActor(int actorId) =>
        m => m.ApprovedActors.Any(e => e.Id == actorId);
    
    public static Expression<Func<Movie, bool>> ByAcceptedActor(int actorId) =>
        m => m.AcceptedOffers.Any(e => e.Actor.Id == actorId);
}