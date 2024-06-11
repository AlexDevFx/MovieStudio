using Microsoft.AspNetCore.Authorization;
using MovieStudio.Contacts.Users;

namespace MovieStudio.Authorization;

public class UserAuthorizationHandler: AuthorizationHandler<UserRoleRequirement>
{
    private readonly IAuthorizedUser _authorizedUser;

    public UserAuthorizationHandler(IAuthorizedUser authorizedUser)
    {
        _authorizedUser = authorizedUser;
    }

    protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, UserRoleRequirement requirement)
    {
        if(context.User.Identity?.IsAuthenticated == true && _authorizedUser.Roles.Intersect(requirement.Roles).Any())
            context.Succeed(requirement);
        return Task.CompletedTask;
    }
}