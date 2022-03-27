using System.ComponentModel.DataAnnotations;

namespace Battleship_State_Tracker.Models
{
    public class Boat
    {
        public int Id { get; set; }
        public int Size { get; set; }
        public Position? HeadPos { get; set; }
        public Position? TailPos { get; set; }
    }
}
