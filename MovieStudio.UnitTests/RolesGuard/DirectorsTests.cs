using MovieStudio.Contacts.Users;
using MovieStudio.Core.Users;

namespace MovieStudio.Test.RolesGuard;

public class DirectorsTests
{
    [Theory]
    [InlineData(UserRoleType.Admin, true)]
    [InlineData(UserRoleType.Director, false)]
    [InlineData(UserRoleType.Actor, false)]
    public void CanCreateDirector_Allowed_For_Admin_Only(UserRoleType roleType, bool expected)
    {
        var createdUser = TestUserBuilder.CreatedUserWithRole(roleType);
        Core.Users.RolesGuard rolesGuard = new();

        bool result = rolesGuard.CanCreateDirector(createdUser);
        
        Assert.Equal(expected, result);
    }
    
    
    [Theory]
    [InlineData(UserRoleType.Admin, true)]
    [InlineData(UserRoleType.Director, true)]
    [InlineData(UserRoleType.Actor, false)]
    public void CanReadDirector_Allowed_For_Admin_Actor(UserRoleType roleType, bool expected)
    {
        var createdUser = TestUserBuilder.CreatedUserWithRole(roleType);
        Core.Users.RolesGuard rolesGuard = new();

        bool result = rolesGuard.CanReadDirector(createdUser);
        
        Assert.Equal(expected, result);
    }
    
    [Theory]
    [InlineData(UserRoleType.Admin, true)]
    [InlineData(UserRoleType.Director, false)]
    [InlineData(UserRoleType.Actor, false)]
    public void CanUpdateDirector_Allowed_For_Admin_Only(UserRoleType roleType, bool expected)
    {
        var createdUser = TestUserBuilder.CreatedUserWithRole(roleType);
        Core.Users.RolesGuard rolesGuard = new();

        bool result = rolesGuard.CanUpdateDirector(createdUser);
        
        Assert.Equal(expected, result);
    }
    
    [Theory]
    [InlineData(UserRoleType.Admin, true)]
    [InlineData(UserRoleType.Director, false)]
    [InlineData(UserRoleType.Actor, false)]
    public void CanDeleteDirector_Allowed_For_Admin_Only(UserRoleType roleType, bool expected)
    {
        var createdUser = TestUserBuilder.CreatedUserWithRole(roleType);
        Core.Users.RolesGuard rolesGuard = new();

        bool result = rolesGuard.CanDeleteDirector(createdUser);
        
        Assert.Equal(expected, result);
    }
}