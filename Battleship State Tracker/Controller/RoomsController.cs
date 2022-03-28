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

        public RoomsController(IRoomRepository roomRepository)
        {
            this._roomRepository = roomRepository;
        }

        // GET: api/<RoomsController>
        [HttpGet]
        public Task<IEnumerable<Room>> GetAllOpenRooms()
        {
            return _roomRepository.GetAllOpenRooms();
        }

        // GET: api/<RoomsController>/1
        [HttpGet("{id}", Name = "GetRoomById")]
        public ActionResult<Room> GetRoomById(int id)
        {
            try
            {
                var room =  _roomRepository.GetRoomById(id);

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
        public ActionResult<Room> CreateNewRoom([FromBody] Room newRoom)
        {
            try
            {
                if (newRoom == null)
                    return BadRequest();

                _roomRepository.CreateRoom(newRoom);
     
                return CreatedAtRoute(nameof(GetRoomById), new { newRoom.Id }, newRoom);

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error creating room");
            }
        }
    }
}
