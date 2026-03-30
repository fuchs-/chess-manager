using System.ComponentModel.DataAnnotations;

namespace ChessManagerAPI.Models;

public class Player
{
    public Player()
    {
    }

    public Player(int id, string name, int rating)
    {
        ID = id;
        Name = name;
        Rating = rating;
    }

    public int ID { get; set; }
    
    [Required]
    [StringLength(50, MinimumLength = 3)]
    public string Name { get; set; } = null!;

    [Range(0, int.MaxValue)]
    public int Rating { get; set; }
}
