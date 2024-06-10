using MovieStudio.Core.Contracts;
using MovieStudio.Core.Users;

namespace MovieStudio.Test;

public class DbStore: IUserRepository
{
    public List<User> Users = new();

    public User? ById(int id) => Users.FirstOrDefault(u => u.Id == id);
}