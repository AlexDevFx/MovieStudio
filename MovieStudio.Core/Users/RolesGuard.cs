using MovieStudio.Core.Movies;

namespace MovieStudio.Core.Users;

public class RolesGuard
{
    public bool CanCreateMovie(User user) => user.DirectorId.HasValue 
                                              && user.HasPermission(UserPerminssionType.CreateMovie);

    public bool CanManageMovie(User user, Movie movie) => user.HasPermission(UserPerminssionType.ManageMovie)
                                                           && movie.DirectorId == user.DirectorId;
    
    public bool CanDeleteMovie(User user, Movie movie) => user.HasPermission(UserPerminssionType.DeleteMovie)
                                                           && movie.DirectorId == user.DirectorId;

    public bool CanReadMovie(User user, Movie movie) => user.HasPermission(UserPerminssionType.ReadMovie);
    
    public bool CanSendOffer(User user, Movie movie) => user.HasPermission(UserPerminssionType.SendOffer)
                                                         && ((movie.DirectorId == user.DirectorId && user.HasRole(UserRoleType.Director)) 
                                                            || user.HasRole(UserRoleType.Actor));
}