using MovieStudio.Core.Users;

namespace MovieStudio.Test.RolesGuard;

public class UsersTests
{
    [Theory]
    [InlineData(UserRoleType.Admin, true)]
    [InlineData(UserRoleType.Director, false)]
    [InlineData(UserRoleType.Actor, false)]
    public void CanCreateUser_Allowed_For_Admin(UserRoleType roleType, bool expected)
    {
        var createdUser = TestUserBuilder.CreatedUserWithRole(roleType);
        Users users = new();

        bool result = users.CanCreateUser(createdUser);
        
        Assert.Equal(expected, result);
    }
    
    
    [Theory]
    [InlineData(UserRoleType.Admin, true)]
    [InlineData(UserRoleType.Director, true)]
    [InlineData(UserRoleType.Actor, true)]
    public void CanReadUser_Allowed_For_Actor_Admin(UserRoleType roleType, bool expected)
    {
        var createdUser = TestUserBuilder.CreatedUserWithRole(roleType);
        Users users = new();

        bool result = users.CanReadUser(createdUser);
        
        Assert.Equal(expected, result);
    }
    
    [Theory]
    [InlineData(UserRoleType.Admin, true)]
    [InlineData(UserRoleType.Director, false)]
    [InlineData(UserRoleType.Actor, true)]
    public void CanUpdateUserData_Allowed_For_Actor_Admin(UserRoleType roleType, bool expected)
    {
        var createdUser = TestUserBuilder.CreatedUserWithRole(roleType);
        Users users = new();

        bool result = users.CanUpdateUser(createdUser);
        
        Assert.Equal(expected, result);
    }
    
    [Theory]
    [InlineData(UserRoleType.Admin, true)]
    [InlineData(UserRoleType.Director, false)]
    [InlineData(UserRoleType.Actor, false)]
    public void CanDeleteUser_Allowed_For_Admin_Only(UserRoleType roleType, bool expected)
    {
        var createdUser = TestUserBuilder.CreatedUserWithRole(roleType);
        Users users = new();

        bool result = users.CanDeleteUser(createdUser);
        
        Assert.Equal(expected, result);
    }
}