namespace Battleship_State_Tracker.Exceptions
{
    public class PlayerNotInASessionException : Exception
    {
        public PlayerNotInASessionException() : base($"Player not in a session.")
        {
        }
    }
}
