using Battleship_State_Tracker.Data;
using Battleship_State_Tracker.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Battleship_State_Tracker.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayersController : ControllerBase
    {
        readonly IPlayerRepository _playerRepository;

        public PlayersController(IPlayerRepository playerRepository)
        {
            this._playerRepository = playerRepository;
        }

        // GET api/<PlayersController>/?username=?password=
        [HttpGet]
        public ActionResult<Player> GetByUsernameAndPassword(string username = "username", string password = "password")
        {
            try
            {
                var player = _playerRepository.FindPlayerByUsernameAndPassword(username, password);

                if (player == null)
                    return NotFound();

                return Ok(player);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    $"Error: {ex}");
            }
        }

        // GET api/<PlayersController>/?username=?password=
        [HttpGet("{playerId}", Name = "GetPlayerById")]
        public async Task<ActionResult<Player>> GetById(int playerId)
        {
            try
            {
                var player = await _playerRepository.FindPlayerById(playerId);

                if (player == null)
                    return NotFound();

                return Ok(player);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    $"Error: {ex}");
            }
        }

        // POST api/<PlayersController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Player newPlayer)
        {
            try
            {
                if (newPlayer == null)
                {
                    return BadRequest();
                }

                Player player = await _playerRepository.CreatePlayer(newPlayer);

                if (player == null)
                {
                    return BadRequest("Player already exist.");
                }

                return StatusCode(StatusCodes.Status200OK, "User created");

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Server error: " + ex.Message);
            }
        }
    }
}
