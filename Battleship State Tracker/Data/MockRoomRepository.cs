using Battleship_State_Tracker.Models;

namespace Battleship_State_Tracker.Data
{
    public class MockRoomRepository : IRoomRepository
    {
        readonly List<Room> mockRooms = new ()
        {
            new Room(){Id = 1, TurnNumber = 0, RoomStatus = new RoomStatus(){ Status = "Open"}, PlayerList = null, Board = null },
            new Room(){Id = 1, TurnNumber = 3, RoomStatus = new RoomStatus(){ Status = "Playing"},
                PlayerList = new List<Player>()
            {
                    new (){Id = 0, Name = "Rook"},
                    new (){Id = 1, Name = "Dog"}

            }, Board = new Board()}
        };

        public Task CloseRoom()
        {
            throw new NotImplementedException();
        }

        public Task<Room> CreateRoom(Room newRoom)
        {
            var room = mockRooms.First();
            return Task.FromResult(room);
        }

        public Task<IEnumerable<Room>> GetAllOpenRooms()
        {
            IEnumerable<Room> rooms = mockRooms.FindAll((room => room.RoomStatus != null && room.RoomStatus.Status == "Open"));
            return Task.FromResult(rooms);
        }

        public Task<Room> GetRoomById(int id)
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
    }
}
