namespace Battleship_State_Tracker.Exceptions
{
    public class RoomFullException : Exception
    {
        public RoomFullException() : base("Room full")
        {
        }
    }
}
