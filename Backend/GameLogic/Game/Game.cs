using Backend.GameLogic.Entity;
using Backend.GameLogic.Item;
using Backend.GameLogic.Player;
using Backend.GameLogic.Room;

namespace Backend.GameLogic.Game
{
    public class Game : IGame
    {
        Dictionary<(int, int), IRoom> map = new Dictionary<(int, int), IRoom>();
        IRoom currentRoom;
        IPlayer player;

        public Game(IPlayer player)
        {
            this.player = player;
        }

        public Game()
        {
            player = new PlayerImpl();
        }

        public IPlayer EndEffect(string Effect)
        {
            throw new NotImplementedException();
        }

        public void EndGame()
        {
            map.Clear();
            currentRoom = null;
            player = new PlayerImpl();
        }

        public (IRoom, bool) EnterRoom((int, int) coords)
        {
            throw new NotImplementedException();
        }

        public List<IEntity> ExecuteEffect(string Effect)
        {
            throw new NotImplementedException();
        }

        public List<IItem> LootCurrentRoom()
        {
            throw new NotImplementedException();
        }


        public (bool, IPlayer) StartGame()
        {

            return (true, player);
        }
    }
}
