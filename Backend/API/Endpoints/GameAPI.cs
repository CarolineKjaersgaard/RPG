using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
namespace API;

[ApiController]
[Route("[controller]")]
public class GameAPI : ControllerBase, IGameAPI
{
    private IGame game;

    public GameAPI(IGame game)
    {
        this.game = game;
    }

    [HttpPost(Name = "StartGame")]
    public IActionResult StartGame()
    {
        (bool, object) res = game.StartGame();
        return Ok(res);
    }

    [HttpGet(Name = "EnterRoom")]
    public IActionResult EnterRoom(int x, int y)
    {
        (object, bool) res = game.EnterRoom((x, y));
        return Ok(res);
    }

    [HttpGet(Name = "LootCurrentRoom")]
    public IActionResult LootCurrentRoom()
    {
        List<object> res = game.LootCurrentRoom();
        return Ok(res);
    }

    [HttpPost(Name = "ExecuteEffect")]
    public IActionResult ExecuteEffect(string effect)
    {
        List<Object> res = game.ExecuteEffect(effect);
        return Ok(res);
    }

    [HttpDelete(Name = "EndEffect")]
    public IActionResult EndEffect(string effect)
    {
        object res = game.EndEffect(effect);
        return Ok(res);
    }

    [HttpDelete(Name = "EndGame")]
    public IActionResult EndGame()
    {
        game.EndGame();
        return Ok();
    }
}