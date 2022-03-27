using System.ComponentModel.DataAnnotations;

namespace Battleship_State_Tracker.Models
{
    public class Position
    {  
        [Key]
        public int Id { get; set; }

        [Required]
        public string? Letter { get; set; }

        [Required]
        public int Number { get; set; }
    }
}
