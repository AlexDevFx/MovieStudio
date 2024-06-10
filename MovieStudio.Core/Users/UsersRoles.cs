namespace MovieStudio.Core.Users;

public static class UsersRoles
{
    public static Dictionary<UserRoleType, UserPerminssionType[]> RolesPermissions = new()
    {
        { UserRoleType.Admin, new [] 
        { 
            UserPerminssionType.CreateDirector, 
            UserPerminssionType.ReadDirector, 
            UserPerminssionType.UpdateDirector, 
            UserPerminssionType.CreateActor, 
            UserPerminssionType.ReadActor,
            UserPerminssionType.UpdateActor,
            UserPerminssionType.DeleteActor,
            UserPerminssionType.CreateUser,
            UserPerminssionType.UpdateUser,
            UserPerminssionType.ReadUser,
            UserPerminssionType.DeleteUser,
            UserPerminssionType.CreateMovie,
            UserPerminssionType.ReadMovie,
            UserPerminssionType.UpdateMovie,
            UserPerminssionType.DeleteMovie,
            UserPerminssionType.CreateGenre,
            UserPerminssionType.ReadGenre,
            UserPerminssionType.UpdateGenre,
            UserPerminssionType.DeleteGenre
        }},
        { UserRoleType.Actor, new []
        {
            UserPerminssionType.ReadMovie, 
            UserPerminssionType.AcceptOffer, 
            UserPerminssionType.RefuseOffer, 
            UserPerminssionType.SendOffer, 
            UserPerminssionType.ReadUser, 
            UserPerminssionType.UpdateUser
        }},
        { UserRoleType.Director, new []
        {
            UserPerminssionType.CreateMovie, 
            UserPerminssionType.UpdateMovie, 
            UserPerminssionType.DeleteMovie, 
            UserPerminssionType.ReadMovie, 
            UserPerminssionType.SendOffer
        }}
    };
}