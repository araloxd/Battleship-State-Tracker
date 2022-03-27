namespace Battleship_State_Tracker.Models
{
    public class Turn
    {
        public int Id { get; set; }
        public Player? Player { get; set; }
        public Shoot? Shoot { get; set; }
    }
}
