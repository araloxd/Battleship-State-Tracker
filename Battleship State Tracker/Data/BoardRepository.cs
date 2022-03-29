using Battleship_State_Tracker.Context;
using Battleship_State_Tracker.Exceptions;
using Battleship_State_Tracker.Models;
using Battleship_State_Tracker.Services;

namespace Battleship_State_Tracker.Data
{
    public class BoardRepository : IBoardRepository
    {
        private readonly BattleshipContext _battleshipContext;
        private readonly GameLogicService _gameLogicService;
        public BoardRepository(BattleshipContext battleshipContext, GameLogicService gameLogicService)
        {
            _battleshipContext = battleshipContext;
            _gameLogicService = gameLogicService;
        }

        public async Task<bool> Fire(Player player, Position position)
        {
            var room = _battleshipContext.Rooms.FirstOrDefault(r => r.PlayerList != null && r.PlayerList.Contains(player));

            if (room == null)
            {
                throw new PlayerNotInASessionException();
            }

            if (room.Board.TurnList.Last().Player.Id == player.Id)
            {
                throw new Exception("You alredy played, waiting for the other player move");
            }

            var checkIfAlredyShootInThatPos = room.Board.TurnList.FindAll(turn => turn.Player.Id == player.Id).FirstOrDefault(t => t.Shoot.ShootPosition == position);
            var enemyFloat = room.Board.PlayersArsenal.FirstOrDefault(p => p.Player.Id != player.Id);
            var hitedBoat = _gameLogicService.CheckForHits(position, enemyFloat.Boats);

            if (checkIfAlredyShootInThatPos != null)
            {
                throw new Exception($"You alredy shoot in that position and whas { (hitedBoat != null ? "HIT" : "MISS") }");
            }


            room.Board.TurnList.Add(new Turn()
            {
                Player = player,
                Shoot = new Shoot()
                {
                    ShootPosition = position
                }
            });

            await _battleshipContext.SaveChangesAsync();


            return hitedBoat!= null ? true : false;

        }
    }
}
