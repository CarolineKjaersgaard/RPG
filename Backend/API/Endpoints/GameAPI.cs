using Backend.Database;
using Backend.GameLogic;
using Backend.GameLogic.EffectImpl.ActiveEffect;
using Backend.GameLogic.Game;
using Backend.GameLogic.ItemImpl;
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
    public static Database database;

    public GameAPI()
    {
        database = new Database();
        game = new Game(database);
    }

    [HttpPost(Name = "StartGame")]
    public IActionResult StartGame()
    {
        //object needs to be a specified model class
        (bool, IPlayer) res = game.StartGame();
        Dictionary<string, object> returnValues = new Dictionary<string, object>
        {
            {"result", res.Item1},
            {"Player", res.Item2.GetDictionaryRepresentation()}
        };
        return EnterRoom(0, 0);
        //return Ok(returnValues);
    }

    [HttpPut(Name = "EnterRoom")]
    public IActionResult EnterRoom(int x, int y)
    {
        (IRoom, bool) res = game.EnterRoom((x, y));
        RoomImpl room = (RoomImpl)res.Item1;
        Dictionary<string, object> roomValues = new Dictionary<string, object>()
        {
            {"title", room.title},
            {"description", room.desc },
            {"enemies", room.GetEnemyDisplayList() },
            {"items", room.GetItemDisplayList() },
            {"doors", room.GetDoorList() }

        };
        Dictionary<string, object> returnValues = new Dictionary<string, object>()
        {
            {"result", res.Item2 },
            {"room", roomValues }
        };

        return Ok(returnValues);
    }

    [HttpGet(Name = "LootCurrentRoom")]
    public IActionResult LootCurrentRoom()
    {
        List<IItem> res = game.LootCurrentRoom();
        Dictionary<string, object> returnValues = new Dictionary<string, object>();
        return Ok(res);
    }

    [HttpDelete(Name = "EndGame")]
    public IActionResult EndGame()
    {
        game.EndGame();
        return Ok();
    }
}