using MovieStudio.Contacts.Users;

namespace MovieStudio.Core.Users;

public static class UsersRoles
{
    public static Dictionary<UserRoleType, UserPermissionType[]> RolesPermissions = new()
    {
        { UserRoleType.Admin, new [] 
        { 
            UserPermissionType.CreateDirector, 
            UserPermissionType.ReadDirector, 
            UserPermissionType.UpdateDirector, 
            UserPermissionType.DeleteDirector,
            UserPermissionType.CreateActor, 
            UserPermissionType.ReadActor,
            UserPermissionType.UpdateActor,
            UserPermissionType.DeleteActor,
            UserPermissionType.CreateUser,
            UserPermissionType.UpdateUser,
            UserPermissionType.ReadUser,
            UserPermissionType.DeleteUser,
            UserPermissionType.CreateMovie,
            UserPermissionType.ReadMovie,
            UserPermissionType.UpdateMovie,
            UserPermissionType.DeleteMovie,
            UserPermissionType.CreateGenre,
            UserPermissionType.ReadGenre,
            UserPermissionType.UpdateGenre,
            UserPermissionType.DeleteGenre
        }},
        { UserRoleType.Actor, new []
        {
            UserPermissionType.ReadMovie, 
            UserPermissionType.AcceptOffer, 
            UserPermissionType.RefuseOffer, 
            UserPermissionType.SendOffer, 
            UserPermissionType.ReadUser, 
            UserPermissionType.UpdateUser,
            UserPermissionType.ReadActor,
            UserPermissionType.UpdateActor
        }},
        { UserRoleType.Director, new []
        {
            UserPermissionType.CreateMovie, 
            UserPermissionType.UpdateMovie, 
            UserPermissionType.DeleteMovie, 
            UserPermissionType.ReadMovie, 
            UserPermissionType.SendOffer,
            UserPermissionType.ReadDirector,
            UserPermissionType.ReadUser
        }}
    };
}