using Battleship_State_Tracker.Models;

namespace Battleship_State_Tracker.Data
{
    public class RoomRepository : IRoomRepository
    {
        public Task<Room> GetRoomById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Room> CreateRoom(Room newRoom)
        {
            throw new NotImplementedException();
        }

        public Task CloseRoom()
        {
            throw new NotImplementedException();
        }

        public Task PlayerJoinsRoom(Player player)
        {
            throw new NotImplementedException();
        }

        public Task PlayerLeavesRoom(Player player)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Room>> GetAllOpenRooms()
        {
            throw new NotImplementedException();
        }
    }
}
