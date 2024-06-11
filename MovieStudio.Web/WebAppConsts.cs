using MovieStudio.Contacts.Users;
using MovieStudio.Core.Users;

namespace MovieStudio;

public static class WebAppConsts
{
    public static class TokenClaims
    {
        public static string ActorId = nameof(ActorId);
        public static string DirectorId = nameof(DirectorId);
        public static string UserId = nameof(UserId);
        public static string Roles = nameof(Roles);
    }

    public static class Roles
    {
        public const string Admin = nameof(Admin);
        public const string Director = nameof(Director);
        public const string Actor = nameof(Actor);
    }

    public static class PolicyNames
    {
        public const string Admin = nameof(Admin);
        public const string Director = nameof(Director);
        public const string Actor = nameof(Actor);
        public const string All = $"{Actor},{Director},{Director}";
    }
    
    private static UserRoleType? FromString(string role)
    {
        return role switch
        {
            Roles.Admin => UserRoleType.Admin,
            Roles.Actor => UserRoleType.Actor,
            Roles.Director => UserRoleType.Director,
            _ => null
        };
    }

    public static HashSet<UserRoleType> RolesFromString(string roles)
    {
        HashSet<UserRoleType> result = new();

        foreach (var role in roles
                     .Split(",")
                     .Select(e => FromString(e))
                     .Where(e => e != null))
        {
            result.Add(role.Value);
        }
        
        return result;
    }
}