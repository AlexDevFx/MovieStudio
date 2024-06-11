using MovieStudio.Contacts.Users;

namespace MovieStudio.Core.Users;

public class UsersBuilder
{
    public User? Create(NewUser newUser)
    {
        return newUser.RoleType switch
        {
            UserRoleType.Actor => new User(newUser.FirstName, newUser.SecondName, newUser.UserName, new Actor()),
            UserRoleType.Director => new User(newUser.FirstName, newUser.SecondName, newUser.UserName, new MovieDirector()),
            UserRoleType.Admin => new User(newUser.FirstName, newUser.SecondName, newUser.UserName, new HashSet<UserRoleType> { UserRoleType.Admin }),
            _ => null
        };
    }
}