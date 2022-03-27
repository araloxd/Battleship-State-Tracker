using System.ComponentModel.DataAnnotations;

namespace Battleship_State_Tracker.Models
{
    public class Player
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(255)]
        public string Name { get; set; } = string.Empty!;

        [Required]
        [MinLength(5, ErrorMessage = "Username must be between 5 and 15 characters long."), MaxLength(15)]
        public string Username { get; set; } = string.Empty!;

        [Required]
        [MinLength(5, ErrorMessage = "Password must be between 5 and 15 characters long.."), MaxLength(15)]
        public string Password { get; set; } = string.Empty!;
    }
}
