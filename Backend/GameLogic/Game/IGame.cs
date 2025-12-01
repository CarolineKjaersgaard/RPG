

using Backend.GameLogic.Entity;
using Backend.GameLogic.ItemImpl;
using Backend.GameLogic.Player;
using Backend.GameLogic;
using Backend.Database.Tables;

public interface IGame
{
    public (bool, IPlayer) StartGame();

    public (IRoom, bool) EnterRoom((int, int) coords);

    public List<IItem> LootCurrentRoom();

    public List<IEntity> ExecuteEffect(string Effect, string target);

    public IPlayer EndEffect(string Effect);

    public void EndGame();

    public List<Enemy> GetEnemies();

    public List<Item> GetItems();

    public Dictionary<(int, int), IRoom> GetMap();
}