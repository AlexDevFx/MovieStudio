using MovieStudio.Contacts.Users;
using MovieStudio.Core.Users;

namespace MovieStudio.Users;

public class WebAuthorizedUser: IAuthorizedUser
{
    public WebAuthorizedUser()
    {
    }

    public int UserId { get; private set; }
    public int? DirectorId { get; private set; }
    public int? ActorId { get; private set; }
    public HashSet<UserRoleType> Roles { get; private set; }

    public void Init(int userId, int? directorId, int? actorId, HashSet<UserRoleType>? roleTypes)
    {
        UserId = userId;
        DirectorId = directorId;
        ActorId = actorId;
        Roles = roleTypes;
    }
}