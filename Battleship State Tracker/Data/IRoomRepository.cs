using Battleship_State_Tracker.Models;

namespace Battleship_State_Tracker.Data
{
    public interface IRoomRepository
    {
        Task<Room> GetRoomById(int id);
        Task<Room> CreateRoom(Player roomCreator);
        Task CloseRoom();
        Task<Room> PlayerJoinsRoom(Room room, Player player);
        Task PlayerLeavesRoom(Player player);
        IEnumerable<Room> GetAllOpenRooms();
    }
}
