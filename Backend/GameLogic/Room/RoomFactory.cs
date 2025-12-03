using Backend.Database.Tables;
using Backend.GameLogic;
using Backend.GameLogic.EffectImpl;
using Backend.GameLogic.Entity;
using Backend.GameLogic.ItemImpl;

namespace Backend.GameLogic
{
    public class RoomFactory : IRoomFactory
    {
        public IRoom CreateRoom(Room roomStats, IGame game, (int, int) coords)
        {
            IRoom room = new RoomImpl(roomStats.Title, true, roomStats.Description, " ", coords);
            if (roomStats.Effect != null)
            {
                EffectFactory effectFactory = new EffectFactory();
                room.SetEffect(effectFactory.CreateEffect(roomStats.Effect));
            }
            List<Enemy> roomEnemies = new List<Enemy>();
            List<Enemy> enemies = game.GetEnemies();
            int totalEnemyDifficulty = 0;
            Random rnd = new Random();
            while (totalEnemyDifficulty < roomStats.Difficulty)
            {
                int index = rnd.Next(0, enemies.Count);
                while (enemies[index].Difficulty + totalEnemyDifficulty > roomStats.Difficulty)
                {
                    index = rnd.Next(0, enemies.Count);
                }
                int packSize = enemies[index].PackSize;
                for (int i = 0; i < packSize; i++)
                {
                    if (totalEnemyDifficulty + enemies[index].Difficulty <= roomStats.Difficulty)
                    {
                        roomEnemies.Add(enemies[index]);
                        totalEnemyDifficulty += enemies[index].Difficulty;
                    }
                }
            }
            IEntityFactory entityFactory = new EntityFactory();
            foreach (Enemy enemy in roomEnemies)
            {
                IEntity monster = entityFactory.CreateEntity(enemy, game);
                room.GetMonsters().Add(monster);
            }
            
            List<Item> roomItems = new List<Item>();
            List<Item> items = game.GetItems();
            int totalItemRarity = 0;
            while (totalItemRarity < roomStats.Rarity)
            {
                int index = rnd.Next(0, items.Count);
                while (items[index].Rarity + totalItemRarity > roomStats.Rarity)
                {
                    index = rnd.Next(0, items.Count);
                }
                roomItems.Add(items[index]);
                totalItemRarity += items[index].Rarity;
            }
            IItemFactory itemFactory = new ItemFactory();
            foreach (Item item in roomItems)
            {
                room.GetItems().Add(itemFactory.Create(item, game));
            }
            Dictionary<(int, int), bool> doors = new Dictionary<(int, int), bool>();
            int doorscreated = 0;
            int remainingSides = 4;
            for(int x = -1; x <= 1; x++)
            {
                for(int y = -1; y <= 1; y++)
                {
                    if(x != y && (x == 0 || y == 0))
                    {
                        int createDoor = rnd.Next(0, 2);
                        if(!game.GetMap().ContainsKey((coords.Item1 + x, coords.Item2 + y)) && ((doorscreated < roomStats.MaxDoors && createDoor == 1) || remainingSides == (roomStats.MinDoors - doorscreated)))
                        {
                            doors.Add((x, y), true);
                            doorscreated++;
                        }
                        else if (game.GetMap().ContainsKey((coords.Item1 + x, coords.Item2 + y)) && game.GetMap()[(coords.Item1 + x, coords.Item2 + y)].HasDoor(coords))
                        {
                            doors.Add((x, y), true);
                            doorscreated++;
                        }
                        else
                        {
                            doors.Add((x, y), false);
                        }
                    }
                    remainingSides--;
                }
            }
            room.SetDoors(doors);
            return room;
        }
    }
}
