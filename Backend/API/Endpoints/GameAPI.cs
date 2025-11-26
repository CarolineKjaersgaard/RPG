using Microsoft.AspNetCore.Mvc;
namespace API;

[ApiController]
[Route("[controller]")]
public class GameAPI : IGameAPI
{
    private IGame game;

    public GameAPI(IGame game)
    {
        this.game = game;
    }

    [HttpPost(Name = "StartGame")]
    public IActionResult StartGame()
    {
        throw new NotImplementedException();
    }

    [HttpGet(Name = "EnterRoom")]
    public IActionResult EnterRoom(int x, int y)
    {
        throw new NotImplementedException();
    }

    [HttpPost(Name = "ExecuteEffect")]
    public IActionResult ExecuteEffect(string effect)
    {
        throw new NotImplementedException();
    }

    [HttpDelete(Name = "EndEffect")]
    public IActionResult EndEffect(string effect)
    {
        throw new NotImplementedException();
    }

    [HttpGet(Name = "LootCurrentRoom")]
    public IActionResult LootCurrentRoom()
    {
        throw new NotImplementedException();
    }

    [HttpDelete(Name = "EndGame")]
    public IActionResult EndGame()
    {
        throw new NotImplementedException();
    }
}