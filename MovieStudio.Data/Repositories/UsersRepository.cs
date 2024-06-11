using MovieStudio.Core.Contracts;
using MovieStudio.Core.Users;

namespace MovieStudio.Data;

public partial class MoviesDbContext: IUserRepository
{
    User? IUserRepository.ById(int id)
    {
        return Users.FirstOrDefault(e => e.Id == id);
    }
}