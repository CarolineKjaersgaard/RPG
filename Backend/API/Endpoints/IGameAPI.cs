
using Microsoft.AspNetCore.Mvc;

public interface IGameAPI
{
    public IActionResult StartGame();

    public IActionResult EnterRoom(int x, int y);

    public IActionResult LootCurrentRoom();

    public IActionResult ExecuteEffect(string effect);

    public IActionResult EndEffect(string effect);

    public IActionResult EndGame();
}