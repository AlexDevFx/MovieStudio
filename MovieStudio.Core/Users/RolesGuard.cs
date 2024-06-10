using MovieStudio.Core.Movies;

namespace MovieStudio.Core.Users;

public class RolesGuard
{
    public bool CanCreateMovie(User user) => user.HasPermission(UserPerminssionType.CreateMovie);

    public bool CanUpdateMovie(User user, Movie movie) => user.HasPermission(UserPerminssionType.UpdateMovie)
                                                           && (movie.DirectorId == user.DirectorId || user.HasRole(UserRoleType.Admin));
    
    public bool CanDeleteMovie(User user, Movie movie) => user.HasPermission(UserPerminssionType.DeleteMovie)
                                                           && (movie.DirectorId == user.DirectorId || user.HasRole(UserRoleType.Admin));

    public bool CanReadMovie(User user, Movie movie)
    {
        return user.HasPermission(UserPerminssionType.ReadMovie)
               && (user.HasRole(UserRoleType.Actor) || user.HasRole(UserRoleType.Admin) ||
                   (user.HasRole(UserRoleType.Director) && user.DirectorId == movie.DirectorId));
    }
    
    public bool CanReadMoviesList(User user) => user.HasPermission(UserPerminssionType.ReadMovie);
    
    public bool CanSendOffer(User user, Movie movie) => user.HasPermission(UserPerminssionType.SendOffer)
                                                         && ((movie.DirectorId == user.DirectorId && user.HasRole(UserRoleType.Director)) 
                                                            || user.HasRole(UserRoleType.Actor));
    
    public bool CanUpdateOwnUserData(User user) => user.HasPermission(UserPerminssionType.UpdateUser);

    public bool CanCreateDirector(User user) => user.HasPermission(UserPerminssionType.CreateDirector);
    public bool CanReadDirector(User user) => user.HasPermission(UserPerminssionType.ReadDirector);
    public bool CanUpdateDirector(User user) => user.HasPermission(UserPerminssionType.UpdateDirector);
    public bool CanDeleteDirector(User user) => user.HasPermission(UserPerminssionType.DeleteDirector);
    public bool CanCreateActor(User user) => user.HasPermission(UserPerminssionType.CreateActor);
    public bool CanReadActor(User user) => user.HasPermission(UserPerminssionType.ReadActor);
    public bool CanUpdateActor(User user) => user.HasPermission(UserPerminssionType.UpdateActor);
    public bool CanDeleteActor(User user) => user.HasPermission(UserPerminssionType.DeleteActor);

    public bool CanCreateGenre(User user) => user.HasPermission(UserPerminssionType.CreateGenre);
    public bool CanReadGenre(User user) => user.HasPermission(UserPerminssionType.ReadGenre);
    public bool CanUpdateGenre(User user) => user.HasPermission(UserPerminssionType.UpdateGenre);
    public bool CanDeleteGenre(User user) => user.HasPermission(UserPerminssionType.DeleteGenre);
    
    public bool CanCreateUser(User user) => user.HasPermission(UserPerminssionType.CreateUser);
    public bool CanReadUser(User user) => user.HasPermission(UserPerminssionType.ReadUser);
    public bool CanUpdateUser(User user) => user.HasPermission(UserPerminssionType.UpdateUser);
    public bool CanDeleteUser(User user) => user.HasPermission(UserPerminssionType.DeleteUser);
}