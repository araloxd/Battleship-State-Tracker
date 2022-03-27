namespace Battleship_State_Tracker.Models
{
    public class Board
    {
        public int Id { get; set; }
        public int RoomId { get; set; }
        public List<Boat>? BoatList { get; set;}
        public List<Turn>? TurnList { get; set; }
    }
}
