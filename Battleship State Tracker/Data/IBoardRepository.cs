using Battleship_State_Tracker.Models;

namespace Battleship_State_Tracker.Data
{
    public interface IBoardRepository
    {
        Task<bool> Fire(Player player, Position shootPosition);
    }
}
