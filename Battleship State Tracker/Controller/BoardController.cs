using Battleship_State_Tracker.Data;
using Battleship_State_Tracker.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Battleship_State_Tracker.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class BoardController : ControllerBase
    {
        private readonly IBoardRepository _boardRepository;
        private readonly PlayersController _playersController;
        public BoardController(IBoardRepository boardRepository, PlayersController playersController)
        {
            this._boardRepository = boardRepository;
            this._playersController = playersController;
        }
        // POST api/<BoardController>
        [HttpPost]
        public async Task<ActionResult<Board>> Shoot(int playerId, Position shootPosition)
        {
            try
            {
                if (playerId == null)
                {
                    return BadRequest("Provide playerId");
                }

                if (shootPosition == null)
                {
                    return BadRequest("Provide position");
                }

                var player = await _playersController.GetById(playerId);

                var actionResultPlayer = (player.Result as OkObjectResult);

                if (actionResultPlayer == null)
                {
                    return NotFound("Player not found");
                }

                var actualPlayer = (Player)actionResultPlayer.Value;


                var updatedRoom = await _boardRepository.Fire(actualPlayer, shootPosition);

                return Ok(updatedRoom);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
