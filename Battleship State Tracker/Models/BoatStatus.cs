using System.ComponentModel.DataAnnotations;

namespace Battleship_State_Tracker.Models
{
    public class BoatStatus
    {
        [Key]
        public int Id { get; set; }
        public string? Status { get; set; }
    }
}
