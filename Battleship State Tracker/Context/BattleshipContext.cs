using Battleship_State_Tracker.Models;
using Microsoft.EntityFrameworkCore;

namespace Battleship_State_Tracker.Context
{
    public class BattleshipContext: DbContext
    {
        public DbSet<Room> Rooms { get; set; } = default!;
        public DbSet<RoomStatus> RoomStatus { get; set; } = default!;
        public DbSet<Player> Players { get; set; } = default!;
        public DbSet<Board> Boards { get; set; } = default!;
        public DbSet<Boat> Boats { get; set; } = default!;
        public DbSet<BoatStatus> BoatStatus { get; set; } = default!;
        public DbSet<Position> Positions { get; set; } = default!;
        public DbSet<Shoot> Shoots { get; set; } = default!;
        public DbSet<Turn> Turns { get; set; } = default!;

        public BattleshipContext(DbContextOptions<BattleshipContext> options) : base(options) { }
    }
}
