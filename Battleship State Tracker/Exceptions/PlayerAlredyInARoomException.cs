using Battleship_State_Tracker.Models;

namespace Battleship_State_Tracker.Exceptions
{
    public class PlayerAlredyInARoomException : Exception
    {
        public PlayerAlredyInARoomException(string playerName = "User")
      : base($"{playerName}, already playing, logout please.")
        {
        }
    }
}
