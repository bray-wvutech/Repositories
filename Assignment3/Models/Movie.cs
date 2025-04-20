namespace Assignment3.Models;

using System.ComponentModel.DataAnnotations;

public class Movie
{
    public int Id { get; set; }
    public string? Title { get; set; }
    [DataType(DataType.Date)]
    [Display(Name ="Release Date")]
    public DateTime ReleaseDate { get; set; }
    
    public string? Genre { get; set; }
    [DataType(DataType.Currency)]
    [Range(1, 100)]
    public decimal Price { get; set; }

    // new image property goes here
    public string Image { get; set; } = "";
}

