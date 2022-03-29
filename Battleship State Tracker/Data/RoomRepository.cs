using Battleship_State_Tracker.Context;
using Battleship_State_Tracker.Exceptions;
using Battleship_State_Tracker.Models;

namespace Battleship_State_Tracker.Data
{
    public class RoomRepository : IRoomRepository
    {
        private readonly BattleshipContext _battleshipContext;

        public RoomRepository(BattleshipContext context)
        {
            _battleshipContext = context;
        }
        public async Task<Room> GetRoomById(int roomId)
        {
            return await _battleshipContext.Rooms.FindAsync(roomId);
        }

        public async Task<Room> CreateRoom(Player roomCreator)
        {
            var newRoom = new Room { PlayerList = new List<Player> { roomCreator }, RoomStatus = new RoomStatus() { Status = RoomStatusTypes.Open.ToString() } };
            await _battleshipContext.Rooms.AddAsync(newRoom);
            await _battleshipContext.SaveChangesAsync();
            return newRoom;
        }

        public Task CloseRoom()
        {
            throw new NotImplementedException();
        }

        public async Task<Room> PlayerJoinsRoom(Room room, Player player)
        {
            var playerAlredyInRoom = _battleshipContext.Rooms.Any(r => r != null && r.PlayerList != null && r.PlayerList.Contains(player));

            if (playerAlredyInRoom)
            {
                throw new PlayerAlredyInARoomException(player.Name);
            }

            if (room != null && room.PlayerList != null && room.PlayerList.Count > 1)
            {
                throw new RoomFullException();
            }

            if (room.PlayerList == null)
            {
                room.PlayerList = new List<Player>();
            }

            room.PlayerList.Add(player);
            await _battleshipContext.SaveChangesAsync();

            return room;
        }

        public IEnumerable<Room> GetAllOpenRooms()
        {
            return _battleshipContext.Rooms.ToList();
        }

        public Task PlayerLeavesRoom(Player player)
        {
            throw new NotImplementedException();
        }
    }
}
