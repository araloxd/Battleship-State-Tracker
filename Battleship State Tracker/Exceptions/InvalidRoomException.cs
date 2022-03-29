using System.Runtime.Serialization;

namespace Battleship_State_Tracker.Exceptions
{
    public class InvalidRoomException : Exception 
    {
        public InvalidRoomException(string roomId) : base($"Invalid Room code : {roomId}")
        {
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            throw new NotImplementedException();
        }
    }
}
