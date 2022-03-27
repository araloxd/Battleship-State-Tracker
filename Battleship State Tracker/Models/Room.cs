using System.ComponentModel.DataAnnotations;

namespace Battleship_State_Tracker.Models
{
    public class Room
    {
        [Key]
        public int Id { get; set; }

        public int TurnNumber { get; set; } = 0;

        public RoomStatus? RoomStatus { get; set; }

        public List<Player>? PlayerList { get; set; }

        public Board? Board { get; set; }
    }
}
