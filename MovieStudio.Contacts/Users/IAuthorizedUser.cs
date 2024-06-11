namespace MovieStudio.Contacts.Users;

public interface IAuthorizedUser
{
   int UserId { get; }
   int? DirectorId { get; }
   int? ActorId { get; }

   public bool HasRole(UserRoleType roleType);
}