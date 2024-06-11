namespace MovieStudio.Contacts.Movies;

public class MovieDto
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public decimal Budget { get; set; }
    public TimeSpan Duration { get; set;}
    public DateTime Started { get; set; }
    public DateTime Ended { get; set; }
}