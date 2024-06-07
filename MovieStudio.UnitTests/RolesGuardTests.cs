using MovieStudio.Core.Users;

namespace MovieStudio.Test;

public class RolesGuardTests
{
    [Theory]
    [InlineData(UserRoleType.Admin, false)]
    [InlineData(UserRoleType.Director, true)]
    [InlineData(UserRoleType.Actor, false)]
    public void CanCreateMovie_Allow_To_Director_Only(UserRoleType roleType, bool expected)
    {
        var createdUser = CreatedUserWithRole(roleType);
        RolesGuard rolesGuard = new();

        bool result = rolesGuard.CanCreateMovie(createdUser);
        
        Assert.Equal(expected, result);
    }

    private static User? CreatedUserWithRole(UserRoleType roleType)
    {
        var userBuilder = new UsersBuilder();

        var newUser = new NewUser("Bill", "Walt", "username@", roleType);
        User? createdUser = userBuilder.Create(newUser);
        

        Assert.NotNull(createdUser);
        
        return createdUser;
    }
}