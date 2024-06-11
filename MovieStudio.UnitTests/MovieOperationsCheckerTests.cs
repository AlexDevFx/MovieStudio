using Moq;
using MovieStudio.Contacts.Users;
using MovieStudio.Core;
using MovieStudio.Core.Contracts;
using MovieStudio.Core.Movies;
using MovieStudio.Core.Users;

namespace MovieStudio.Test;

public class MovieOperationsCheckerTests
{
    private readonly DbStore _dbStore = new DbStore();

    #region Create Movie

    [Fact]
    public void CanCreateMovie_Director_Success()
    {
        var user = CreateUserWithRole(UserRoleType.Director);
        
        Mock<IAuthorizedUser> authorizedUserMock = new Mock<IAuthorizedUser>();
        authorizedUserMock.Setup(e => e.UserId)
            .Returns(user.Id);
        
        var movieOperationChecker = new MovieOperationsChecker(_dbStore, authorizedUserMock.Object, new Core.Users.RolesGuard());

        string? error = movieOperationChecker.CanCreateMovie(new NewMovie(user.DirectorId ?? -1,
            "New Era",
            "The movie about history",
            35_000_000,
            new[] { new Genre() },
            TimeSpan.FromHours(3),
            DateTime.Now,
            DateTime.Now.AddMonths(6)));
        
        Assert.Null(error);
    }
    
    [Fact]
    public void CanCreateMovie_Admin_Fail()
    {
        var user = CreateUserWithRole(UserRoleType.Admin);
        
        Mock<IAuthorizedUser> authorizedUserMock = new Mock<IAuthorizedUser>();
        authorizedUserMock.Setup(e => e.UserId)
            .Returns(user.Id);
        
        var movieOperationChecker = new MovieOperationsChecker(_dbStore, authorizedUserMock.Object, new Core.Users.RolesGuard());

        string? error = movieOperationChecker.CanCreateMovie(new NewMovie(user.DirectorId ?? -1,
            "New Era",
            "The movie about history",
            35_000_000,
            new[] { new Genre() },
            TimeSpan.FromHours(3),
            DateTime.Now,
            DateTime.Now.AddMonths(6)));
        
        Assert.NotNull(error);
    }
    
    [Fact]
    public void CanCreateMovie_Actor_Fail()
    {
        var user = CreateUserWithRole(UserRoleType.Actor);
        
        Mock<IAuthorizedUser> authorizedUserMock = new Mock<IAuthorizedUser>();
        authorizedUserMock.Setup(e => e.UserId)
            .Returns(user.Id);
        
        var movieOperationChecker = new MovieOperationsChecker(_dbStore, authorizedUserMock.Object, new Core.Users.RolesGuard());

        string? error = movieOperationChecker.CanCreateMovie(new NewMovie(user.DirectorId ?? -1,
            "New Era",
            "The movie about history",
            35_000_000,
            new[] { new Genre() },
            TimeSpan.FromHours(3),
            DateTime.Now,
            DateTime.Now.AddMonths(6)));
        
        Assert.NotNull(error);
    }
    
    #endregion

    private User? CreateUserWithRole(UserRoleType roleType)
    {
        User? user = TestUserBuilder.CreatedUserWithRole(roleType);

        if (user != null)
        {
            _dbStore.Users.Add(user);
        }
        
        return user;
    }
}