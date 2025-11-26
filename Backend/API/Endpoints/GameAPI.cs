using Microsoft.AspNetCore.Mvc;
namespace API;

public class GameAPI : IGameAPI
{
    public IActionResult EndEffect(string effect)
    {
        throw new NotImplementedException();
    }

    public IActionResult EndGame()
    {
        throw new NotImplementedException();
    }

    public IActionResult EnterRoom(int x, int y)
    {
        throw new NotImplementedException();
    }

    public IActionResult ExecuteEffect(string effect)
    {
        throw new NotImplementedException();
    }

    public IActionResult LootCurrentRoom()
    {
        throw new NotImplementedException();
    }

    public IActionResult StartGame()
    {
        throw new NotImplementedException();
    }
}