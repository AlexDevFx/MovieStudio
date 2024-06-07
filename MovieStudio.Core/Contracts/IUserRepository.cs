using MovieStudio.Core.Users;

namespace MovieStudio.Core.Contracts;

public interface IUserRepository
{
    User? ById(int id);
}