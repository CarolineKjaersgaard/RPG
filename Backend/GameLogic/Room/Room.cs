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
        Dictionary<(int, int), bool> doors = new Dictionary<(int, int), bool>();
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
            Dictionary<string, object> enemyDisplayList = new Dictionary<string, object>();
            return enemyDisplayList;
        }
    }
}