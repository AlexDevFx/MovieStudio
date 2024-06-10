using MovieStudio.Core.Users;

namespace MovieStudio.Test.RolesGuard;

public class GenreTests
{
    [Theory]
    [InlineData(UserRoleType.Admin, true)]
    [InlineData(UserRoleType.Director, false)]
    [InlineData(UserRoleType.Actor, false)]
    public void CanCreateGenre_Allowed_For_Admin_Only(UserRoleType roleType, bool expected)
    {
        var createdUser = TestUserBuilder.CreatedUserWithRole(roleType);
        Users users = new();

        bool result = users.CanCreateGenre(createdUser);
        
        Assert.Equal(expected, result);
    }
    
    
    [Theory]
    [InlineData(UserRoleType.Admin, true)]
    [InlineData(UserRoleType.Director, false)]
    [InlineData(UserRoleType.Actor, false)]
    public void CanReadGenre_Allowed_For_Admin_Only(UserRoleType roleType, bool expected)
    {
        var createdUser = TestUserBuilder.CreatedUserWithRole(roleType);
        Users users = new();

        bool result = users.CanReadGenre(createdUser);
        
        Assert.Equal(expected, result);
    }
    
    [Theory]
    [InlineData(UserRoleType.Admin, true)]
    [InlineData(UserRoleType.Director, false)]
    [InlineData(UserRoleType.Actor, false)]
    public void CanUpdateGenre_Allowed_For_Admin_Only(UserRoleType roleType, bool expected)
    {
        var createdUser = TestUserBuilder.CreatedUserWithRole(roleType);
        Users users = new();

        bool result = users.CanUpdateGenre(createdUser);
        
        Assert.Equal(expected, result);
    }
    
    [Theory]
    [InlineData(UserRoleType.Admin, true)]
    [InlineData(UserRoleType.Director, false)]
    [InlineData(UserRoleType.Actor, false)]
    public void CanDeleteGenre_Allowed_For_Admin_Only(UserRoleType roleType, bool expected)
    {
        var createdUser = TestUserBuilder.CreatedUserWithRole(roleType);
        Users users = new();

        bool result = users.CanDeleteGenre(createdUser);
        
        Assert.Equal(expected, result);
    }
}