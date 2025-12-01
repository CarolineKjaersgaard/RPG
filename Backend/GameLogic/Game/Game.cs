using Backend.Database;
using Backend.Database.Tables;
using Backend.GameLogic.Entity;
using Backend.GameLogic.ItemImpl;
using Backend.GameLogic.Player;

namespace Backend.GameLogic.Game
{
    public class Game : IGame
    {
        public Dictionary<(int, int), IRoom> map = new Dictionary<(int, int), IRoom>();
        public IRoom? currentRoom;
        public IPlayer player;
        private IDatabase database;
        private Random rnd;
        private List<Enemy> enemies = new List<Enemy>();
        private List<Item> Items = new List<Item>();
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
                List<Room> rooms = database.GetItems<Room>("", "");
                room = CreateRoom(player.GetCoords(), rooms);
            }
            bool containsMonsters = false;
            List<IEntity> monsters = room.GetMonsters();
            /*if(coords == (0,0) && monsters.Count > 0)
            {
                room.GetMonsters().Clear();
                monsters.Clear();
            }*/
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

        private IRoom CreateRoom((int, int) coords, List<Room> rooms)
        {
            int chosenRoom = rnd.Next(0, rooms.Count);
            Room roomStats = rooms[chosenRoom];
            RoomFactory roomFactory = new RoomFactory();
            IRoom room = roomFactory.CreateRoom(roomStats, this, coords);
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
                if(monster.GetHealth() > 0)
                {
                    List<string> effects = monster.GetEffectNames();
                    int chosenEffect = rnd.Next(0, effects.Count);
                    monster.ExecuteEffect(effects[chosenEffect], player);
                }
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
            List<Room> rooms = new List<Room>() {database.GetItem<Room>() };
            if(rooms.Count == 0)
            {
                rooms.Add(new Room() { Id = "0", Description = "this room should not appear", Title = "test room", Type = new RoomType() { Id = "0", Title = "test room" }, TypeId = "0", MinDoors = 1, MaxDoors = 4, Rarity = 10, Difficulty = 10 });
            }
            CreateRoom(player.GetCoords(), rooms);
            return (true, player);
        }

        public List<Enemy> GetEnemies()
        {
            if(enemies.Count == 0)
            {
                enemies = database.GetItems<Enemy>();
                if(enemies.Count == 0)
                {
                    enemies.Add(new Enemy() { Description = "this enemy should not appear", Id = "0", Title = "test enemy", Type = new EnemyType() {Id = "0", Title = "test enemy" }, TypeId = "0", WeaponId = "0", Weapon = new Item() { Description = "this item should not appear", Id = "0", Title = "test item", Type = new ItemType() { Id = "0", Title = "test item" }, TypeId = "0", Rarity = 10, isLootable = true }, Difficulty = 5, PackSize = 2 });
                }
            }
            return enemies;
        }

        public List<Item> GetItems()
        {
            if(Items.Count == 0)
            {
                Items = database.GetItems<Item>();
                if(Items.Count == 0)
                {
                    Items.Add(new Item() { Description = "this item should not appear", Id = "0", Title = "test item", Type = new ItemType() {Id = "0", Title = "test item" }, TypeId = "0", Rarity = 10, isLootable = true });
                }
            }
            return Items;
        }

        public Dictionary<(int, int), IRoom> GetMap()
        {
            return map;
        }
    }
}
