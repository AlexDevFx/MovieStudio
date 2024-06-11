using MovieStudio.Contacts.Users;
using MovieStudio.Core.Users;

namespace MovieStudio.Test;

public class UsersBuilderTest
{
    [Theory]
    [InlineData(UserRoleType.Actor)]
    [InlineData(UserRoleType.Director)]
    [InlineData(UserRoleType.Admin)]
    public void Create_WithRole_Success(UserRoleType roleType)
    {
        var userBuilder = new UsersBuilder();

        var newUser = new NewUser("Bill", "Walt", "username@", roleType);
        User? createdUser = userBuilder.Create(newUser);
        
        Assert.NotNull(createdUser);
        Assert.True(createdUser.HasRole(newUser.RoleType));
        Assert.Equal(newUser.FirstName, createdUser.FirstName);
        Assert.Equal(newUser.SecondName, createdUser.SecondName);
        Assert.Equal(newUser.UserName, createdUser.UserName);
    }
}