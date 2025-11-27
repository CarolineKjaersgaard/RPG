

using Backend.GameLogic.Entity;
using Backend.GameLogic.Item;
using Backend.GameLogic.Player;
using Backend.GameLogic;

public interface IGame
{
    public (bool, IPlayer) StartGame();

    public (IRoom, bool) EnterRoom((int, int) coords);

    public List<IItem> LootCurrentRoom();

    public List<IEntity> ExecuteEffect(string Effect, string target);

    public IPlayer EndEffect(string Effect);

    public void EndGame();
}