using MovieStudio.Core.Contracts;
using MovieStudio.Core.Movies;

namespace MovieStudio.Core.Users;

public class MovieOperationsChecker
{
    private readonly IUserRepository _userRepository;
    private readonly IAuthorizedUser _authorizedUser;
    private readonly Users _users;

    public MovieOperationsChecker(IUserRepository userRepository,
        IAuthorizedUser authorizedUser,
        Users users)
    {
        _users = users;
        _authorizedUser = authorizedUser;
        _userRepository = userRepository;
    }

    public string? CanCreateMovie(NewMovie newMovie)
    {
        if (!IsUserAllowPerform(_users.CanCreateMovie))
        {
            return new("Movie creation is not allowed");
        }
        
        var errors = newMovie.Validate();
        if (errors.Any())
        {
            return string.Join(",", errors);
        }

        return null;
    }
    
    public string? CanDeleteMovie(Movie? movie)
    {
        if (movie == null)
        {
            return new("Movie is not found");
        }

        if(!IsUserAllowPerform(u => _users.CanDeleteMovie(u, movie)))
        {
            return new("Movie removing is forbidden");
        }

        return null;
    }
    
    public string? CanUpdateMovie(Movie? movie)
    {
        if (movie == null)
        {
            return new("Movie is not found");
        }

        if (!IsUserAllowPerform(u => _users.CanUpdateMovie(u, movie)))
        {
            return new("You can not update movie");
        }


        return null;
    }
    
    public string? CanSendOffer(Movie movie, Actor actor)
    {
        IsUserAllowPerform(u => _users.CanSendOffer(u, movie));
        
        if (movie.TotalSpentForCompensations + actor.Compensation >= movie.Budget)
        {
            return new("The movie budget doesn't allow to sent offer this actor");
        }

        return null;
    }
    
    public string? CanStartFilming(Movie movie, Func<DateTime> currentTime)
    {
        IsUserAllowPerform(u => _users.CanUpdateMovie(u, movie));
        
        if (movie.Status != MovieStatus.NotStarted)
        {
            return new("You can start filming a movie with status [Not Started] only");
        }
        
        if (movie.TotalSpentForCompensations > movie.Budget)
        {
            return new("Requested compensation is greater than movie budget");
        }

        if (!movie.ApprovedActors.Any())
        {
            return new("You don have any actors for filming");
        }

        if (movie.Started > currentTime())
        {
            return new("You can start before planned date");
        }

        return null;
    }
    
    private bool IsUserAllowPerform(Func<User, bool> operation)
    {
        User? user = _userRepository.ById(_authorizedUser.UserId);

        if (user == null)
        {
            return false;
        }

        return operation(user);
    }
}