using MovieStudio.Contacts.Users;
using MovieStudio.Core.Contracts;
using MovieStudio.Core.Movies;

namespace MovieStudio.Core.Users;

public class MovieOperationsChecker
{
    private readonly IUserRepository _userRepository;
    private readonly IAuthorizedUser _authorizedUser;
    private readonly RolesGuard _rolesGuard;

    public MovieOperationsChecker(IUserRepository userRepository,
        IAuthorizedUser authorizedUser,
        RolesGuard rolesGuard)
    {
        _rolesGuard = rolesGuard;
        _authorizedUser = authorizedUser;
        _userRepository = userRepository;
    }

    public string? CanCreateMovie(NewMovie newMovie)
    {
        if (!IsUserAllowPerform(_rolesGuard.CanCreateMovie))
        {
            return "Movie creation is not allowed";
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
            return "Movie is not found";
        }

        if(!IsUserAllowPerform(u => _rolesGuard.CanDeleteMovie(u, movie)))
        {
            return "Movie removing is forbidden";
        }

        return null;
    }
    
    public string? CanUpdateMovie(Movie? movie)
    {
        if (movie == null)
        {
            return "Movie is not found";
        }

        if (!IsUserAllowPerform(u => _rolesGuard.CanUpdateMovie(u, movie)))
        {
            return "You can not update movie";
        }


        return null;
    }
    
    public string? CanSendOffer(Movie movie, Actor actor)
    {
        IsUserAllowPerform(u => _rolesGuard.CanSendOffer(u, movie));
        
        if (movie.TotalSpentForCompensations + actor.Compensation >= movie.Budget)
        {
            return "The movie budget doesn't allow to sent offer this actor";
        }

        return null;
    }
    
    public string? CanStartFilming(Movie movie, Func<DateTime> currentTime)
    {
        IsUserAllowPerform(u => _rolesGuard.CanUpdateMovie(u, movie));
        
        if (movie.Status != MovieStatus.NotStarted)
        {
            return "You can start filming a movie with status [Not Started] only";
        }
        
        if (movie.TotalSpentForCompensations > movie.Budget)
        {
            return "Requested compensation is greater than movie budget";
        }

        if (!movie.ApprovedActors.Any())
        {
            return "You don have any actors for filming";
        }

        if (movie.Started > currentTime())
        {
            return "You can start before planned date";
        }

        return null;
    }

    public string? ReadMoviesList()
    {
        if (!IsUserAllowPerform(_rolesGuard.CanReadMoviesList))
        {
            return "You can not list movies";
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