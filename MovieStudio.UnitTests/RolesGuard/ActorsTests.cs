using MovieStudio.Core.Users;

namespace MovieStudio.Test.RolesGuard;

public class ActorsTests
{
    [Theory]
    [InlineData(UserRoleType.Admin, true)]
    [InlineData(UserRoleType.Director, false)]
    [InlineData(UserRoleType.Actor, false)]
    public void CanCreateActor_Allowed_For_Admin_Only(UserRoleType roleType, bool expected)
    {
        var createdUser = TestUserBuilder.CreatedUserWithRole(roleType);
        Users users = new();

        bool result = users.CanCreateActor(createdUser);
        
        Assert.Equal(expected, result);
    }
    
    
    [Theory]
    [InlineData(UserRoleType.Admin, true)]
    [InlineData(UserRoleType.Director, false)]
    [InlineData(UserRoleType.Actor, true)]
    public void CanReadActor_Allowed_For_Admin_Actor(UserRoleType roleType, bool expected)
    {
        var createdUser = TestUserBuilder.CreatedUserWithRole(roleType);
        Users users = new();

        bool result = users.CanReadActor(createdUser);
        
        Assert.Equal(expected, result);
    }
    
    [Theory]
    [InlineData(UserRoleType.Admin, true)]
    [InlineData(UserRoleType.Director, false)]
    [InlineData(UserRoleType.Actor, true)]
    public void CanUpdateActor_Allowed_For_Admin_Only(UserRoleType roleType, bool expected)
    {
        var createdUser = TestUserBuilder.CreatedUserWithRole(roleType);
        Users users = new();

        bool result = users.CanUpdateActor(createdUser);
        
        Assert.Equal(expected, result);
    }
    
    [Theory]
    [InlineData(UserRoleType.Admin, true)]
    [InlineData(UserRoleType.Director, false)]
    [InlineData(UserRoleType.Actor, false)]
    public void CanDeleteActor_Allowed_For_Admin_Only(UserRoleType roleType, bool expected)
    {
        var createdUser = TestUserBuilder.CreatedUserWithRole(roleType);
        Users users = new();

        bool result = users.CanDeleteActor(createdUser);
        
        Assert.Equal(expected, result);
    }
}