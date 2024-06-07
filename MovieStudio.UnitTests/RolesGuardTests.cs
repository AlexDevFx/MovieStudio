using MovieStudio.Core.Movies;
using MovieStudio.Core.Users;

namespace MovieStudio.Test;

public class RolesGuardTests
{
    [Theory]
    [InlineData(UserRoleType.Admin, false)]
    [InlineData(UserRoleType.Director, true)]
    [InlineData(UserRoleType.Actor, false)]
    public void CanCreateMovie_Allow_For_Director_Only(UserRoleType roleType, bool expected)
    {
        var createdUser = CreatedUserWithRole(roleType);
        RolesGuard rolesGuard = new();

        bool result = rolesGuard.CanCreateMovie(createdUser);
        
        Assert.Equal(expected, result);
    }
    
    [Theory]
    [InlineData(UserRoleType.Admin, false)]
    [InlineData(UserRoleType.Director, true)]
    [InlineData(UserRoleType.Actor, false)]
    public void CanDeleteMovie_Allow_For_Director_Only(UserRoleType roleType, bool expected)
    {
        var createdUser = CreatedUserWithRole(roleType);
        RolesGuard rolesGuard = new();

        bool result = rolesGuard.CanDeleteMovie(createdUser, 
            new Movie(createdUser?.Director?.Id ?? -1, 
                "New Movie", 
                "Something interesting about space", 
                100_000_000, 
                new []{ new Genre() }, 
                TimeSpan.FromHours(2.5), 
                DateTime.Now, 
            DateTime.Now.AddMonths(4)));
        
        Assert.Equal(expected, result);
    }
    
    [Theory]
    [InlineData(UserRoleType.Admin, false)]
    [InlineData(UserRoleType.Director, true)]
    [InlineData(UserRoleType.Actor, false)]
    public void CanUpdateMovie_Allow_For_Director_Only(UserRoleType roleType, bool expected)
    {
        var createdUser = CreatedUserWithRole(roleType);
        RolesGuard rolesGuard = new();

        bool result = rolesGuard.CanManageMovie(createdUser, 
            new Movie(createdUser?.Director?.Id ?? -1, 
                "New Movie", 
                "Something interesting about space", 
                100_000_000, 
                new []{ new Genre() }, 
                TimeSpan.FromHours(2.5), 
                DateTime.Now, 
                DateTime.Now.AddMonths(4)));
        
        Assert.Equal(expected, result);
    }
    
    [Theory]
    [InlineData(UserRoleType.Admin, false)]
    [InlineData(UserRoleType.Director, true)]
    [InlineData(UserRoleType.Actor, true)]
    public void CanReadMovie_Allow_For_Director_Actor(UserRoleType roleType, bool expected)
    {
        var createdUser = CreatedUserWithRole(roleType);
        RolesGuard rolesGuard = new();

        bool result = rolesGuard.CanReadMovie(createdUser, 
            new Movie(createdUser?.Director?.Id ?? -1, 
                "New Movie", 
                "Something interesting about space", 
                100_000_000, 
                new []{ new Genre() }, 
                TimeSpan.FromHours(2.5), 
                DateTime.Now, 
                DateTime.Now.AddMonths(4)));
        
        Assert.Equal(expected, result);
    }
    
    [Theory]
    [InlineData(UserRoleType.Admin, false)]
    [InlineData(UserRoleType.Director, true)]
    [InlineData(UserRoleType.Actor, true)]
    public void CanSendOfferForMovie_Allow_For_Director_Actor(UserRoleType roleType, bool expected)
    {
        var createdUser = CreatedUserWithRole(roleType);
        RolesGuard rolesGuard = new();

        bool result = rolesGuard.CanSendOffer(createdUser, 
            new Movie(createdUser?.Director?.Id ?? -1, 
                "New Movie", 
                "Something interesting about space", 
                100_000_000, 
                new []{ new Genre() }, 
                TimeSpan.FromHours(2.5), 
                DateTime.Now, 
                DateTime.Now.AddMonths(4)));
        
        Assert.Equal(expected, result);
    }

    private User? CreatedUserWithRole(UserRoleType roleType)
    {
        var userBuilder = new UsersBuilder();

        var newUser = new NewUser("Bill", "Walt", "username@", roleType);
        User? createdUser = userBuilder.Create(newUser);

        Assert.NotNull(createdUser);
        
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

    private int RandomId()
    {
        return new Random(DateTime.Now.Millisecond).Next(1, int.MaxValue);
    }
}