namespace MovieStudio.Contacts.Users;

public interface IAuthorizedUser
{
   int UserId { get; }
   int? DirectorId { get; }
   int? ActorId { get; }

   HashSet<UserRoleType> Roles { get; }

   public void Init(int userId, int? directorId, int? actorId, HashSet<UserRoleType>? roleTypes);
}