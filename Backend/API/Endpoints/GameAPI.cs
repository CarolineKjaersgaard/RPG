using Backend.Database;
using Backend.GameLogic;
using Backend.GameLogic.Effect.ActiveEffect;
using Backend.GameLogic.Game;
using Backend.GameLogic.Item;
using Backend.GameLogic.Player;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.InteropServices;
namespace API;

[ApiController]
[Route("[controller]")]
public class GameAPI : ControllerBase, IGameAPI
{
    public static IGame game;

    public GameAPI(IDatabase database)
    {
        game = new Game(database);
    }

    [HttpPost(Name = "StartGame")]
    public IActionResult StartGame()
    {
        //object needs to be a specified model class
        (bool, IPlayer) res = game.StartGame();
        Dictionary<string, object> playerValues = new Dictionary<string, object>()
        {
            {"name", res.Item2.GetName() },
            {"health", res.Item2.GetHealth() },
            {"max health", res.Item2.GetMaxHealth() },
            {"inventory", res.Item2.GetItems() },
            
        };
        Dictionary<string, object> returnValues = new Dictionary<string, object>
        {
            { "result", res.Item1},
            {"Player",  playerValues}
        };       

        return Ok(returnValues);
    }

    [HttpPut(Name = "EnterRoom")]
    public IActionResult EnterRoom(int x, int y)
    {
        (IRoom, bool) res = game.EnterRoom((x, y));
        return Ok(res);
    }

    [HttpGet(Name = "LootCurrentRoom")]
    public IActionResult LootCurrentRoom()
    {
        List<IItem> res = game.LootCurrentRoom();
        return Ok(res);
    }

    [HttpDelete(Name = "EndGame")]
    public IActionResult EndGame()
    {
        game.EndGame();
        return Ok();
    }
}