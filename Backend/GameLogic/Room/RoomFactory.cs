using Backend.Database.Tables;
using Backend.GameLogic;
using Backend.GameLogic.EffectImpl;
using Backend.GameLogic.Entity;
using Backend.GameLogic.ItemImpl;

namespace Backend.GameLogic
{
    public class RoomFactory : IRoomFactory
    {
        public IRoom CreateRoom(Room roomStats, IGame game)
        {
            IRoom room = new RoomImpl(roomStats.Title, true, roomStats.Description, " ", (0,0));
            if(roomStats.Effect != null)
            {
                EffectFactory effectFactory = new EffectFactory();
                room.SetEffect(effectFactory.CreateEffect(roomStats.Effect));
            }
            List<Enemy> roomEnemies = new List<Enemy>();
            List<Enemy> enemies = game.GetEnemies();
            int totalEnemyDifficulty = 0;
            Random rnd = new Random();
            while(totalEnemyDifficulty < roomStats.Difficulty)
            {
                int index = rnd.Next(0, enemies.Count);
                while(enemies[index].Difficulty + totalEnemyDifficulty > roomStats.Difficulty)
                {
                    index = rnd.Next(0, enemies.Count);
                }
                int packSize = rnd.Next(1, 4);
                for(int i = 0; i < packSize; i++)
                {
                    if(totalEnemyDifficulty + enemies[index].Difficulty <= roomStats.Difficulty)
                    {
                        roomEnemies.Add(enemies[index]);
                        totalEnemyDifficulty += enemies[index].Difficulty;
                    }
                }
            }
            IEntityFactory entityFactory = new EntityFactory();
            foreach(Enemy enemy in roomEnemies)
            {
                room.GetMonsters().Add(entityFactory.CreateEntity(enemy, game));
            }

            
            return room;
        }
    }
}
