using System.Collections.Specialized;
using Backend.Database.Tables;
using Backend.GameLogic.EffectImpl;
using Backend.GameLogic.Entity;
using Backend.GameLogic.ItemImpl;

namespace Backend.GameLogic
{
    public class RoomImpl : IRoom
    {
        public string title;
        bool isUnlocked;
        public string desc;
        public Dictionary<(int, int), bool> doors = new Dictionary<(int, int), bool>();
        public (int, int) entryDoor = (0,0);
        IEffect? effect;
        public string image;
        List<IEntity> monsters = new List<IEntity>();
        List<IItem> items = new List<IItem>();
        (int, int) coords;

        public RoomImpl(string title, bool isUnlocked, string desc, string image, (int, int) coords)
        {
            this.title = title;
            this.isUnlocked = isUnlocked;
            this.desc = desc;
            this.image = image;
            this.coords = coords;
        }

        public IEffect GetEffect()
        {
            return effect;
        }

        public List<IItem> GetItems()
        {
            return items;
        }

        public List<IEntity> GetMonsters()
        {
            return monsters;
        }

        public void SetEffect(IEffect effect)
        {
            this.effect = effect;
        }

        public void SetEntryDoor((int, int) playerCoords)
        {
            (int, int) index = (playerCoords.Item1 - coords.Item1, playerCoords.Item2 - coords.Item2);
            if(doors.ContainsKey(index))
            {
                entryDoor = index;
            }
        }

        public Dictionary<string, object> GetEnemyDisplayList()
        {
            if (GetMonsters().Count == 0)
            {
                throw new Exception("no monsters");
            }
            Dictionary<string, object> enemyDisplayList = new Dictionary<string, object>();
            foreach(IEntity entity in monsters)
            {
                int count = 1;
                string key = entity.GetName();
                while(enemyDisplayList.ContainsKey(key))
                {
                    key = entity.GetName() + count;
                    count++;
                }
                entity.SetName(key);
                enemyDisplayList.Add(key, entity.GetDictionaryRepresentation());
            }
            return enemyDisplayList;
        }

        public Dictionary<string, object> GetItemDisplayList()
        {
            Dictionary<string, object> itemDisplayList = new Dictionary<string, object>();
            foreach(IItem item in items)
            {
                int count = 1;
                string key = item.GetName();
                while (itemDisplayList.ContainsKey(key))
                {
                    key = item.GetName() + count;
                    count++;
                }
                itemDisplayList.Add(key, item.GetDictionaryRepresentation());
            }
            return itemDisplayList;
        }
        public Dictionary<string, bool> GetDoorList()
        {
            Dictionary<string, bool> doorList = new Dictionary<string, bool>();
            foreach((int, int) coords in doors.Keys)
            {
                doorList.Add($"({coords.Item1}, {coords.Item2})", doors[coords]);
            }
            return doorList;
        }

        public bool HasDoor((int, int) coords)
        {
            (int, int) relativeCoords = (coords.Item1 - this.coords.Item1, coords.Item2 - this.coords.Item2);
            if (doors.ContainsKey(relativeCoords))
            {
                return doors[(coords.Item1 - this.coords.Item1, coords.Item2 - this.coords.Item2)];
            }
            return false;
        }

        public void SetDoors(Dictionary<(int, int), bool> doors)
        {
            this.doors = doors;
        }
    }
}