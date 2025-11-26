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
        IDatabase database;
        Random rnd;
        public Game(IPlayer player, IDatabase database)
        {
            this.player = player;
            this.database = database;
        }

        public Game(IDatabase database)
        {
            player = new PlayerImpl();
            this.database = database;
        }

        public IPlayer EndEffect(string Effect)
        {
            player.EndEffect(Effect);
            return player;
        }

        public void EndGame()
        {
            map.Clear();
            currentRoom = null;
            player = new PlayerImpl();
        }

        public (IRoom, bool) EnterRoom((int, int) coords)
        {
            IRoom room;
            if(map.ContainsKey(coords))
            {
                room = map[coords];
            }
            else
            {
                room = CreateRoom(coords);
            }
            bool containsMonsters = false;
            List<IEntity> monsters = room.GetMonsters();
            foreach(IEntity monster in monsters)
            {
                if(monster.GetHealth() > 0)
                {
                    containsMonsters = true;
                    break;
                }
            }
            room.SetEntryDoor(player.GetCoords());
            return (room, containsMonsters);
        }

        private IRoom CreateRoom((int, int) coords)
        {
            return null;
        }

        public List<IEntity> ExecuteEffect(string effect, string target)
        {
            List<IEntity> currentRoomMonsters = currentRoom.GetMonsters();
            
            IEntity targetObject = player;
            foreach(IEntity monster in currentRoomMonsters)
            {
                if(monster.GetName() == target)
                {
                    targetObject = monster;
                    break;
                }
            }
            player.ExecuteEffect(effect, targetObject);
            foreach(IEntity monster in currentRoomMonsters)
            {
                List<string> effects = monster.GetEffectNames();
                int chosenEffect = rnd.Next(0, effects.Count);
                monster.ExecuteEffect(effects[chosenEffect], player);
            }
            currentRoomMonsters.Add(player);
            return currentRoomMonsters;
        }

        public List<IItem> LootCurrentRoom()
        {
            throw new NotImplementedException();
        }


        public (bool, IPlayer) StartGame()
        {
            rnd = new Random();
            return (true, player);
        }
    }
}
