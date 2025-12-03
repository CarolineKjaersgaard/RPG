using System;
using Backend.Database.Tables;

namespace Backend.Database.Handlers
{
    public class Seeder
    {
        public Context _context;
        public Parser _parser;
        public Seeder(Context context, Parser parser) {
            _context = context;
            _parser = parser;
        }
        public void SeedRoomTypes(string filePath)
        {
            Console.WriteLine("*-*--------trying to seed----------*-*");
            List<RoomType> rows = _parser.Parse<RoomType>(filePath);
            foreach (var row in rows)
            {
                var existing = _context.RoomTypes.Find(row.Id);
                if (existing == null)
                {
                    _context.RoomTypes.Add(row);
                    Console.WriteLine("*-*--------seeding----------*-*");
                }
                else
                {
                    _context.Entry(existing).CurrentValues.SetValues(row);
                }
            }
            _context.SaveChanges();
        }

        public void SeedItemTypes(string filePath)
        {
            List<ItemType> rows = _parser.Parse<ItemType>(filePath);
            foreach (var row in rows)
            {
                var existing = _context.ItemTypes.Find(row.Id);
                if (existing == null)
                {
                    _context.ItemTypes.Add(row);
                }
                else
                {
                    _context.Entry(existing).CurrentValues.SetValues(row);
                }
            }
            _context.SaveChanges();
        }

        public void SeedEnemyTypes(string filePath)
        {
            List<EnemyType> rows = _parser.Parse<EnemyType>(filePath);
            foreach (var row in rows)
            {
                var existing = _context.EnemyTypes.Find(row.Id);
                if (existing == null)
                {
                    _context.EnemyTypes.Add(row);
                }
                else
                {
                    _context.Entry(existing).CurrentValues.SetValues(row);
                }
            }
            _context.SaveChanges();
        }

        public void SeedEffectTypes(string filePath)
        {
            List<EffectType> rows = _parser.Parse<EffectType>(filePath);
            foreach (var row in rows)
            {
                var existing = _context.EffectTypes.Find(row.Id);
                if (existing == null)
                {
                    _context.EffectTypes.Add(row);
                }
                else
                {
                     _context.Entry(existing).CurrentValues.SetValues(row);
                }
            }
            _context.SaveChanges();
        }

        public void SeedRooms(string filePath)
        {
            List<Room> rows = _parser.Parse<Room>(filePath);
            foreach (var row in rows)
            {
                var existing = _context.Rooms.Find(row.Id);
                if (existing == null)
                {
                    _context.Rooms.Add(row);
                }
                else
                {
                    _context.Entry(existing).CurrentValues.SetValues(row);
                }
            }
            _context.SaveChanges();
        }

        public void SeedItems(string filePath)
        {
            List<Item> rows = _parser.Parse<Item>(filePath);
            foreach (var row in rows)
            {
                var existing = _context.Items.Find(row.Id);
                if (existing == null)
                {
                    _context.Items.Add(row);
                }
                else
                {
                    _context.Entry(existing).CurrentValues.SetValues(row);
                }
            }
            _context.SaveChanges();
        }

        public void SeedEnemies(string filePath)
        {
            List<Enemy> rows = _parser.Parse<Enemy>(filePath);
            foreach (var row in rows)
            {
                var existing = _context.Enemies.Find(row.Id);
                if (existing == null)
                {
                    _context.Enemies.Add(row);
                }
                else
                {
                    _context.Entry(existing).CurrentValues.SetValues(row);
                }
            }
            _context.SaveChanges();
        }

        public void SeedEffects(string filePath)
        {
            List<Effect> rows = _parser.Parse<Effect>(filePath);
            foreach (var row in rows)
            {
                var existing = _context.Effects.Find(row.Id);
                if (existing == null)
                {
                    _context.Effects.Add(row);
                }
                else
                {
                    _context.Entry(existing).CurrentValues.SetValues(row);
                }
            }
            _context.SaveChanges();
        }

        public void SeedLootInRooms(string filePath)
        {
            List<LootInRoom> rows = _parser.Parse<LootInRoom>(filePath);
            foreach (var row in rows)
            {
                var existing = _context.LootInRooms.Find(row.Id);
                if (existing == null)
                {
                    _context.LootInRooms.Add(row);
                }
                else
                {
                    _context.Entry(existing).CurrentValues.SetValues(row);
                }
            }
            _context.SaveChanges();
        }

        public void SeedLootOnEnemies(string filePath)
        {
            List<LootOnEnemy> rows = _parser.Parse<LootOnEnemy>(filePath);
            foreach (var row in rows)
            {
                var existing = _context.LootOnEnemies.Find(row.Id);
                if (existing == null)
                {
                    _context.LootOnEnemies.Add(row);
                }
                else
                {
                    _context.Entry(existing).CurrentValues.SetValues(row);
                }
            }
            _context.SaveChanges();
        }

        public void SeedEnemiesInRooms(string filePath)
        {
            List<EnemyInRoom> rows = _parser.Parse<EnemyInRoom>(filePath);
            foreach (var row in rows)
            {
                var existing = _context.EnemiesInRooms.Find(row.Id);
                if (existing == null)
                {
                    _context.EnemiesInRooms.Add(row);
                }
                else
                {
                    _context.Entry(existing).CurrentValues.SetValues(row);
                }
            }
            _context.SaveChanges();
        }
    }
}