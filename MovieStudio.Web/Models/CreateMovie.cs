using System.ComponentModel.DataAnnotations;

namespace MovieStudio.Models;

public class CreateMovie
{
    [MaxLength(200)]
    public string Title { get; set; }
    
    [MaxLength(200)]
    public string Description { get; set; }
    
    
    public decimal Budget;
    
    public List<int> SelectedGenres { get; set; }
    
    public TimeSpan Duration { get; set; }  
    
    public DateTime StartFilming { get; set; }
    
    public  DateTime EndFilming { get; set; } 
}