

public interface IGame
{
    public (bool, object) StartGame();

    public (object, bool) EnterRoom((int, int) coords);

    public List<object> LootCurrentRoom();

    public List<object> ExecuteEffect(string Effect);

    public object EndEffect(string Effect);

    public void EndGame();
}