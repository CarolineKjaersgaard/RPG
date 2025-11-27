using System.Collections.Specialized;
using Backend.GameLogic.Effect;
using Backend.GameLogic.Entity;
using Backend.GameLogic.Item;

namespace Backend.GameLogic
{
    public class RoomImpl : IRoom
    {
        string title;
        bool isUnlocked;
        string desc;
        /// <summary>
        /// 0 = no door
        /// 1 = closed door
        /// 2 = open door
        /// </summary>
        Dictionary<(int, int), int> doors = new Dictionary<(int, int), int>();
        (int, int) entryDoor = (0,0);
        IEffect effect;
        string image;
        List<IEntity> monsters = new List<IEntity>();
        List<IItem> items = new List<IItem>();
        (int, int) coords;
        public List<IItem> GetItems()
        {
            return items;
        }

        public List<IEntity> GetMonsters()
        {
            return monsters;
        }

        public void SetEntryDoor((int, int) playerCoords)
        {
            (int, int) index = (playerCoords.Item1 - coords.Item1, playerCoords.Item2 - coords.Item2);
            if(doors.ContainsKey(index))
            {
                
            }
        }
    }
}