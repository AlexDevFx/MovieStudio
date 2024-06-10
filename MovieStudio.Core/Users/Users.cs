using MovieStudio.Core.Movies;

namespace MovieStudio.Core.Users;

public class Users
{
    public bool CanCreateMovie(User user) => user.HasPermission(UserPermissionType.CreateMovie);

    public bool CanUpdateMovie(User user, Movie movie) => user.HasPermission(UserPermissionType.UpdateMovie)
                                                           && (movie.DirectorId == user.DirectorId || user.HasRole(UserRoleType.Admin));
    
    public bool CanDeleteMovie(User user, Movie movie) => user.HasPermission(UserPermissionType.DeleteMovie)
                                                           && (movie.DirectorId == user.DirectorId || user.HasRole(UserRoleType.Admin));

    public bool CanReadMovie(User user, Movie movie)
    {
        return user.HasPermission(UserPermissionType.ReadMovie)
               && (user.HasRole(UserRoleType.Actor) || user.HasRole(UserRoleType.Admin) ||
                   (user.HasRole(UserRoleType.Director) && user.DirectorId == movie.DirectorId));
    }
    
    public bool CanReadMoviesList(User user) => user.HasPermission(UserPermissionType.ReadMovie);
    
    public bool CanSendOffer(User user, Movie movie) => user.HasPermission(UserPermissionType.SendOffer)
                                                         && ((movie.DirectorId == user.DirectorId && user.HasRole(UserRoleType.Director)) 
                                                            || user.HasRole(UserRoleType.Actor));

    public bool CanCreateDirector(User user) => user.HasPermission(UserPermissionType.CreateDirector);
    public bool CanReadDirector(User user) => user.HasPermission(UserPermissionType.ReadDirector) && CanReadUser(user);
    public bool CanUpdateDirector(User user) => user.HasPermission(UserPermissionType.UpdateDirector);
    public bool CanDeleteDirector(User user) => user.HasPermission(UserPermissionType.DeleteDirector);
    public bool CanCreateActor(User user) => user.HasPermission(UserPermissionType.CreateActor);
    public bool CanReadActor(User user) => user.HasPermission(UserPermissionType.ReadActor) && CanReadUser(user);
    public bool CanUpdateActor(User user) => user.HasPermission(UserPermissionType.UpdateActor);
    public bool CanDeleteActor(User user) => user.HasPermission(UserPermissionType.DeleteActor);

    public bool CanCreateGenre(User user) => user.HasPermission(UserPermissionType.CreateGenre);
    public bool CanReadGenre(User user) => user.HasPermission(UserPermissionType.ReadGenre);
    public bool CanUpdateGenre(User user) => user.HasPermission(UserPermissionType.UpdateGenre);
    public bool CanDeleteGenre(User user) => user.HasPermission(UserPermissionType.DeleteGenre);
    
    public bool CanCreateUser(User user) => user.HasPermission(UserPermissionType.CreateUser);
    public bool CanReadUser(User user) => user.HasPermission(UserPermissionType.ReadUser);
    public bool CanUpdateUser(User user) => user.HasPermission(UserPermissionType.UpdateUser);
    public bool CanDeleteUser(User user) => user.HasPermission(UserPermissionType.DeleteUser);
}