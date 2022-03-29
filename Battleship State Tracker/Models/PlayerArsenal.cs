namespace Battleship_State_Tracker.Models
{
    public class PlayerArsenal
    {
        public int Id { get; set; }
        public Player Player { get; set; } 
       public List<Boat> Boats { get; set; }
    }
}
