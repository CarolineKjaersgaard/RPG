using Backend.GameLogic.Entity;
using Backend.GameLogic.Item;
using Backend.GameLogic.Player;
using Backend.GameLogic.Room;

namespace Backend.GameLogic.Game
{
    public class Game : IGame
    {
        public Dictionary<(int, int), IRoom> map = new Dictionary<(int, int), IRoom>();
        public IRoom? currentRoom;
        public IPlayer player;
        private IDatabase database;
        private Random rnd;
        public Game(IPlayer player, IDatabase database)
        {
            this.player = player;
            this.database = database;
            rnd = new Random();
        }

        public Game(IDatabase database)
        {
            player = new PlayerImpl();
            this.database = database;
            rnd = new Random();
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
            if(coords == (0,0) && monsters.Count > 0)
            {
                room.GetMonsters().Clear();
                monsters.Clear();
            }
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
            List<ITable> rooms = database.GetItems<ITable>("", "");
            int chosenRoom = rnd.Next(0, rooms.Count);
            ITable roomStats = rooms[chosenRoom];
            RoomFactory roomFactory = new RoomFactory();
            IRoom room = roomFactory.CreateRoom(roomStats);
            map.Add(coords, room);
            return room;
        }

        public List<IEntity> ExecuteEffect(string effect, string target)
        {
            if(currentRoom == null)
            {
                throw new Exception("no room has been entered");
            }
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
            if(currentRoom == null)
            {
                throw new Exception("no room has been entered");
            }
            List<IItem> items = currentRoom.GetItems();
            
            foreach(IEntity monster in currentRoom.GetMonsters())
            {
                List<IItem> monsterItems = monster.GetItems();
                foreach(IItem  item in monsterItems)
                {
                    if(item.CanBeLooted())
                    {
                        items.Add(item);
                    }
                }
                monster.GetItems().Clear();
            }
            foreach(IItem item in items)
            {
                player.AddItem(item);
            }
            currentRoom.GetItems().Clear();
            return items;
        }


        public (bool, IPlayer) StartGame()
        {
            CreateRoom(player.GetCoords());
            return (true, player);
        }
    }
}
