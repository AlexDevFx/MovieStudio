namespace MovieStudio.Core.Users;

public static class UsersRoles
{
    public static Dictionary<UserRoleType, UserPerminssionType[]> RolesPermissions = new()
    {
        { UserRoleType.Admin, new [] { UserPerminssionType.CreateActor, UserPerminssionType.CreateDirector }},
        { UserRoleType.Actor, new [] { UserPerminssionType.ReadMovie, UserPerminssionType.AcceptOffer, UserPerminssionType.RefuseOffer, UserPerminssionType.SendOffer }},
        { UserRoleType.Director, new [] { UserPerminssionType.CreateMovie, UserPerminssionType.ManageMovie, UserPerminssionType.DeleteMovie, UserPerminssionType.ReadMovie, UserPerminssionType.SendOffer }}
    };
}