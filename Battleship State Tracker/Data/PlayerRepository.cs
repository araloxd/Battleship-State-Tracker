using Battleship_State_Tracker.Context;
using Battleship_State_Tracker.Models;

namespace Battleship_State_Tracker.Data
{
    public class PlayerRepository : IPlayerRepository
    {
        private readonly BattleshipContext _battleshipContext;

        public PlayerRepository(BattleshipContext battleshipContext)
        {
            _battleshipContext = battleshipContext;
        }
        public async Task<Player> CreatePlayer(Player player)
        {
            //Do some player entity validations maybe.
            var existPlayer = _battleshipContext.Players.Any(p => p.Username == player.Username);
            if (!existPlayer)
            {
                await _battleshipContext.Players.AddAsync(player);
                await _battleshipContext.SaveChangesAsync();

                return player;
            }

            return null;
        }

        public Player FindPlayerByUsernameAndPassword(string username, string password)
        {
            return _battleshipContext.Players.FirstOrDefault(p => p.Username == username && p.Password == password);
        }

        public async Task<Player> FindPlayerById(int playerId)
        {
            return await _battleshipContext.Players.FindAsync(playerId);
        }

    }
}
