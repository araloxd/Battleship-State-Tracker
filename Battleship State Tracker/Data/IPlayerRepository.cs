using Battleship_State_Tracker.Models;

namespace Battleship_State_Tracker.Data
{
    public interface IPlayerRepository
    {
        Task<Player> CreatePlayer(Player player);
        Task<Player> FindPlayerById(int playerId);
        Player FindPlayerByUsernameAndPassword(string username, string password);
    }
}
