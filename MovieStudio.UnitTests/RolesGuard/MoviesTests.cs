using MovieStudio.Contacts.Users;
using MovieStudio.Core.Movies;
using MovieStudio.Core.Users;

namespace MovieStudio.Test.RolesGuard;

public class MoviesTests
{
    [Theory]
    [InlineData(UserRoleType.Admin, true)]
    [InlineData(UserRoleType.Director, true)]
    [InlineData(UserRoleType.Actor, false)]
    public void CanCreateMovie_Allowed_For_Director_Admin(UserRoleType roleType, bool expected)
    {
        var createdUser = TestUserBuilder.CreatedUserWithRole(roleType);
        Core.Users.RolesGuard rolesGuard = new();

        bool result = rolesGuard.CanCreateMovie(createdUser);
        
        Assert.Equal(expected, result);
    }
    
    [Theory]
    [InlineData(UserRoleType.Admin, true)]
    [InlineData(UserRoleType.Director, true)]
    [InlineData(UserRoleType.Actor, false)]
    public void CanDeleteMovie_Allowed_For_Director_Admin(UserRoleType roleType, bool expected)
    {
        var createdUser = TestUserBuilder.CreatedUserWithRole(roleType);
        Core.Users.RolesGuard rolesGuard = new();

        bool result = rolesGuard.CanDeleteMovie(createdUser, 
            new Movie(createdUser?.Director?.Id ?? -1, 
                "New Movie", 
                "Something interesting about space", 
                100_000_000, 
                new []{ new MovieGenre() }, 
                TimeSpan.FromHours(2.5), 
                DateTime.Now, 
            DateTime.Now.AddMonths(4)));
        
        Assert.Equal(expected, result);
    }
    
    [Theory]
    [InlineData(UserRoleType.Admin, true)]
    [InlineData(UserRoleType.Director, true)]
    [InlineData(UserRoleType.Actor, false)]
    public void CanUpdateMovie_Allowed_For_Director_Admin(UserRoleType roleType, bool expected)
    {
        var createdUser = TestUserBuilder.CreatedUserWithRole(roleType);
        Core.Users.RolesGuard rolesGuard = new();

        bool result = rolesGuard.CanUpdateMovie(createdUser, 
            new Movie(createdUser?.Director?.Id ?? -1, 
                "New Movie", 
                "Something interesting about space", 
                100_000_000, 
                new []{ new MovieGenre() }, 
                TimeSpan.FromHours(2.5), 
                DateTime.Now, 
                DateTime.Now.AddMonths(4)));
        
        Assert.Equal(expected, result);
    }
    
    [Theory]
    [InlineData(UserRoleType.Admin, true)]
    [InlineData(UserRoleType.Director, true)]
    [InlineData(UserRoleType.Actor, true)]
    public void CanReadMovie_Allowed_For_Director_Admin(UserRoleType roleType, bool expected)
    {
        var createdUser = TestUserBuilder.CreatedUserWithRole(roleType);
        Core.Users.RolesGuard rolesGuard = new();

        bool result = rolesGuard.CanReadMovie(createdUser, 
            new Movie(createdUser?.Director?.Id ?? -1, 
                "New Movie", 
                "Something interesting about space", 
                100_000_000, 
                new []{ new MovieGenre() }, 
                TimeSpan.FromHours(2.5), 
                DateTime.Now, 
                DateTime.Now.AddMonths(4)));
        
        Assert.Equal(expected, result);
    }
    
    [Theory]
    [InlineData(UserRoleType.Admin, false)]
    [InlineData(UserRoleType.Director, true)]
    [InlineData(UserRoleType.Actor, true)]
    public void CanSendOfferForMovie_Allowed_For_Director_Actor(UserRoleType roleType, bool expected)
    {
        var createdUser = TestUserBuilder.CreatedUserWithRole(roleType);
        Core.Users.RolesGuard rolesGuard = new();

        bool result = rolesGuard.CanSendOffer(createdUser, 
            new Movie(createdUser?.Director?.Id ?? -1, 
                "New Movie", 
                "Something interesting about space", 
                100_000_000, 
                new []{ new MovieGenre() }, 
                TimeSpan.FromHours(2.5), 
                DateTime.Now, 
                DateTime.Now.AddMonths(4)));
        
        Assert.Equal(expected, result);
    }
    
    [Fact]
    public void CanSendOfferForMovie_Allowed_Director_For_Owned()
    {
        var createdUser = TestUserBuilder.CreatedUserWithRole(UserRoleType.Director);
        Core.Users.RolesGuard rolesGuard = new();

        bool result = rolesGuard.CanSendOffer(createdUser, 
            new Movie(0, 
                "New Movie", 
                "Something interesting about space", 
                100_000_000, 
                new []{ new MovieGenre() }, 
                TimeSpan.FromHours(2.5), 
                DateTime.Now, 
                DateTime.Now.AddMonths(4)));
        
        Assert.False(result);
    }
    
    [Theory]
    [InlineData(UserRoleType.Admin, true)]
    [InlineData(UserRoleType.Director, true)]
    [InlineData(UserRoleType.Actor, true)]
    public void CanReadMoviesList_Allowed_For_Director_Actor_Admin(UserRoleType roleType, bool expected)
    {
        var createdUser = TestUserBuilder.CreatedUserWithRole(roleType);
        Core.Users.RolesGuard rolesGuard = new();

        bool result = rolesGuard.CanReadMoviesList(createdUser);
        
        Assert.Equal(expected, result);
    }
    
    [Theory]
    [InlineData(UserRoleType.Admin, true)]
    [InlineData(UserRoleType.Director, false)]
    [InlineData(UserRoleType.Actor, true)]
    public void CanReadMovie_Allowed_Of_Another_Director(UserRoleType roleType, bool expected)
    {
        var createdUser = TestUserBuilder.CreatedUserWithRole(roleType);
        Core.Users.RolesGuard rolesGuard = new();

        bool result = rolesGuard.CanReadMovie(createdUser, 
            new Movie(0, 
                "New Movie", 
                "Something interesting about space", 
                100_000_000, 
                new []{ new MovieGenre() }, 
                TimeSpan.FromHours(2.5), 
                DateTime.Now, 
                DateTime.Now.AddMonths(4)));
        
        Assert.Equal(expected,result);
    }
}