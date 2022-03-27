using Battleship_State_Tracker.Models;
using Microsoft.EntityFrameworkCore;

namespace Battleship_State_Tracker.Context
{
    public class BattleshipContext: DbContext
    {
        public DbSet<Room>? Rooms { get; set; }
        public DbSet<RoomStatus>? RoomStatus { get; set; }
        public DbSet<Player>? Players { get; set; }
        public DbSet<Board>? Boards { get; set; }
        public DbSet<Boat>? Boats { get; set; }
        public DbSet<BoatStatus>? BoatStatus { get; set; }
        public DbSet<Position>? Positions { get; set; }
        public DbSet<Shoot>? Shoots { get; set; }
        public DbSet<Turn>? Turns { get; set; }

        public BattleshipContext(DbContextOptions<BattleshipContext> options) : base(options) { }
    }
}
