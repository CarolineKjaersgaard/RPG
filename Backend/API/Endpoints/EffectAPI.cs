using API;
using Backend.GameLogic.Entity;
using Backend.GameLogic.Game;
using Backend.GameLogic.Player;
using Microsoft.AspNetCore.Mvc;

namespace Backend.API.Endpoints
{
    [ApiController]
    [Route("[controller]")]
    public class EffectAPI:ControllerBase
    {
        [HttpPost(Name = "ExecuteEffect")]
        public IActionResult ExecuteEffect(string effect, string target)
        {
            List<IEntity> res = GameAPI.game.ExecuteEffect(effect, target);
            return Ok(res);
        }

        [HttpDelete(Name = "EndEffect")]
        public IActionResult EndEffect(string effect)
        {
            IPlayer res = GameAPI.game.EndEffect(effect);
            return Ok(res);
        }
    }
}
