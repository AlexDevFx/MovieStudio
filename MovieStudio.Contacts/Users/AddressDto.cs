namespace MovieStudio.Contacts.Users;

public class AddressDto
{
    public string City { get; set; }
    public string Street { get; set; }
    public string Apartment { get; set; }
    public string PostIndex { get; set; }

    public override string ToString()
    {
        return $"{PostIndex} {City}, {Street}, {Apartment}";
    }
}