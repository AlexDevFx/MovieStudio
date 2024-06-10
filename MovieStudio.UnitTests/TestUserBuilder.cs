using MovieStudio.Core.Users;

namespace MovieStudio.Test;

public static class TestUserBuilder
{
    public static User? CreatedUserWithRole(UserRoleType roleType)
    {
        var userBuilder = new UsersBuilder();

        var newUser = new NewUser("Bill", "Walt", "username@", roleType);
        User? createdUser = userBuilder.Create(newUser);

        Assert.NotNull(createdUser);

        createdUser.Id = RandomId();
        
        switch (roleType)
        {
            case UserRoleType.Director:
                createdUser.Director.Id = RandomId();
                createdUser.DirectorId = createdUser.Director.Id;
                break;
            case UserRoleType.Actor:
                createdUser.Actor.Id = RandomId();
                createdUser.ActorId = createdUser.Actor.Id;
                break;
        }
        
        return createdUser;
    }

    public static int RandomId()
    {
        return new Random(DateTime.Now.Millisecond).Next(1, int.MaxValue);
    }
}