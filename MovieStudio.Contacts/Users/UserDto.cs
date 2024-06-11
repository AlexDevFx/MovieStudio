namespace MovieStudio.Contacts.Users;

public class UserDto
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string SecondName { get; set; }
    public string UserName { get; set; }
    
    public int? DirectorId { get; set; }
    
    public int? ActorId { get; set; }
}