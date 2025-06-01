using Demo_API.Data;
using Demo_API.Features.Players.CreatePlayer;
using Demo_API.Features.Players.GetPlayerById;
using Demo_API.Models;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Demo_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayerController : ControllerBase
    {
        
        private readonly ISender _sender;
        public PlayerController( ISender sender) {
            
            this._sender = sender;
        }

        [HttpPost]

        public async Task<ActionResult<int>> CreatePlayer(CreatePlayerCommand command)
        {
            var playerId = await _sender.Send(command);
            return Ok(playerId);
        }


        [HttpGet("{id}")] 

        public async Task<IActionResult> GetPlayerById(int id)
        {
            var player = await _sender.Send(new GetPlayerByIdQuery(id));
            if (player is null)
            {   
                return NotFound();
            }
            return Ok(player);
        }

    }
}
