using Battleship_State_Tracker.Data;
using Battleship_State_Tracker.Models;
using Microsoft.AspNetCore.Mvc;

namespace Battleship_State_Tracker.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomsController : ControllerBase
    {
        private readonly IRoomRepository _roomRepository;
        private readonly PlayersController _playersController;

        public RoomsController(IRoomRepository roomRepository, PlayersController playerController)
        {
            this._roomRepository = roomRepository;
            this._playersController = playerController;
        }

        // GET: api/<RoomsController>
        [HttpGet]
        public IEnumerable<Room> GetAllOpenRooms()
        {
            return _roomRepository.GetAllOpenRooms();
        }

        // GET: api/<RoomsController>/1
        [HttpGet("{id}", Name = "GetRoomById")]
        public async Task<ActionResult<Room>> GetRoomById(int id)
        {
            try
            {
                var room = await _roomRepository.GetRoomById(id);

                if (room == null)
                    return NotFound();

                return Ok(room);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    $"Error: {ex}");
            }
        }

        // POST api/<RoomsController>
        [HttpPost]
        public async Task<ActionResult<Room>> CreateNewRoom([FromBody] Player playerThatCreatedTheRoom)
        {
            try
            {
                if (playerThatCreatedTheRoom == null)
                {
                    return BadRequest();
                }

                var newRoom = await _roomRepository.CreateRoom(playerThatCreatedTheRoom);

                return newRoom;

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error creating room");
            }
        }



        /* Ideal endpoint for client w/ UI.
        [HttpPost]
        public async Task<ActionResult<Room>> PlayerJoinRoom([FromBody] Player player, [FromBody] Room room)
        */

        [HttpGet("{roomId}/{playerId}", Name = "PlayerJoinsRoom")]
        public async Task<ActionResult<Room>> PlayerJoinRoom(int roomId, int playerId)
        {
            try
            {
                var room = await GetRoomById(roomId);
                var player = await _playersController.GetById(playerId);

                var actionResultRoom = (room.Result as OkObjectResult);
                var actionResultPlayer = (player.Result as OkObjectResult);

                if (actionResultRoom == null)
                {
                    return NotFound("Room not found");
                }

                if (actionResultPlayer == null)
                {
                    return NotFound("Player not found");
                }

                var actualRoom = (Room)actionResultRoom.Value;
                var actualPlayer = (Player)actionResultPlayer.Value;


                var updatedRoom = await _roomRepository.PlayerJoinsRoom(actualRoom, actualPlayer);

                return Ok(updatedRoom);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
