using Battleship_State_Tracker.Models;

namespace Battleship_State_Tracker.Data
{
    public interface IRoomRepository
    {
        Task<Room> GetRoomById(int id);
        Task<Room> CreateRoom(Room newRoom);
        Task CloseRoom();
        Task PlayerJoinsRoom(Player player);
        Task PlayerLeavesRoom(Player player);
        Task<IEnumerable<Room>> GetAllOpenRooms();
    }
}
