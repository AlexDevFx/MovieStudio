using Microsoft.AspNetCore.Authorization;
using MovieStudio.Contacts.Users;

namespace MovieStudio.Authorization;

public class UserRoleRequirement: IAuthorizationRequirement
{
    public UserRoleRequirement(params UserRoleType[] roles)
    {
        Roles = roles.ToHashSet();
    }

    public HashSet<UserRoleType> Roles { get; private set; }
}