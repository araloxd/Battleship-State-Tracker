namespace Battleship_State_Tracker.Exceptions
{
    public class InvalidUserException : Exception
    {
        public InvalidUserException() : base("User not found")
        {
        }
    }
}
