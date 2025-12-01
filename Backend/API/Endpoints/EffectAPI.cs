using API;
using Backend.GameLogic.Entity;
using Backend.GameLogic.Game;
using Backend.GameLogic.ItemImpl;
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
            Dictionary<string, object> returnValues = new Dictionary<string, object>();
            foreach (IEntity entity in res)
            {
                Dictionary<string, object> values = entity.GetDictionaryRepresentation();
                string key = entity.GetName();
                int count = 1;
                while (returnValues.ContainsKey(key))
                {
                    key = entity.GetName() + count;
                    count++;
                }
                returnValues.Add(key, values);
            }
            return Ok(returnValues);
        }

        [HttpDelete(Name = "EndEffect")]
        public IActionResult EndEffect(string effect)
        {
            IPlayer res = GameAPI.game.EndEffect(effect);
            return Ok(res.GetDictionaryRepresentation());
        }
    }
}
