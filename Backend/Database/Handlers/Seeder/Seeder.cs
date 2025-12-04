using System;
using Backend.Database.Tables;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

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
            IEnumerable<RoomType> rows = _parser.Parse<RoomType>(filePath);
            foreach (var row in rows)
            {
                var existing = _context.RoomTypes.Find(row.RoomTypeId);
                if (existing == null)
                {
                    _context.RoomTypes.Add(row);
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
            IEnumerable<ItemType> rows = _parser.Parse<ItemType>(filePath);
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
            IEnumerable<EnemyType> rows = _parser.Parse<EnemyType>(filePath);
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
            try
            {
                IEnumerable<EffectType> rows = _parser.Parse<EffectType>(filePath);
                foreach (var row in rows)
                {
                    var existing = _context.EffectTypes.Find(row.EffectTypeId);
                    EffectType type = row;
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
            catch (Exception e)
            {
                if(e.InnerException != null)
                {
                    Console.WriteLine(e.InnerException.Message);
                }
                else
                {
                    Console.WriteLine(e.Message); 
                }
            }
        }

        public void SeedRooms(string filePath)
        {
            try
            {
                IEnumerable<Room> rows = _parser.Parse<Room>(filePath);
                foreach (var row in rows)
                {
                    var roomType = _context.RoomTypes.Find(row.TypeId);
                    row.Type = roomType;
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
            catch (DbUpdateException e)
            {
                Console.WriteLine(e.Message);
            }
            
        }

        public void SeedItems(string filePath)
        {
            IEnumerable<Item> rows = _parser.Parse<Item>(filePath);
            foreach (var row in rows)
            {
                var effect = _context.Effects.Find(row.EffectId);
                row.Effect = effect;
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
            IEnumerable<Enemy> rows = _parser.Parse<Enemy>(filePath);
            foreach (var row in rows)
            {
                /*var effect = _context.Effects.Find(row.EffectId);
                row.Effect = effect;
                var item = _context.Items.Find(row.WeaponId);
                row.Weapon = item;*/
                //var effect = _context.EnemyTypes.Find(row.TypeId);
                //row.Type = effect;
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
            IEnumerable<Effect> rows = _parser.Parse<Effect>(filePath);
            foreach (var row in rows)
            {
                var effectType = _context.EffectTypes.Find(row.TypeId);
                row.Type = effectType;
                var existing = _context.Effects.Find(row.EffectId);
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
            IEnumerable<LootInRoom> rows = _parser.Parse<LootInRoom>(filePath);
            foreach (var row in rows)
            {
                var room = _context.Rooms.Find(row.RoomId);
                row.Room = room;
                var item = _context.Items.Find(row.ItemId);
                row.Item = item;
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
            IEnumerable<LootOnEnemy> rows = _parser.Parse<LootOnEnemy>(filePath);
            foreach (var row in rows)
            {
                var enemy = _context.Enemies.Find(row.EnemyId);
                row.Enemy = enemy;
                var item = _context.Items.Find(row.ItemId);
                row.Item = item;
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
            IEnumerable<EnemyInRoom> rows = _parser.Parse<EnemyInRoom>(filePath);
            foreach (var row in rows)
            {
                var existing = _context.EnemiesInRooms.Find(row.Id);
                var room = _context.Rooms.Find(row.RoomId);
                row.Room = room;
                var enemy = _context.Enemies.Find(row.EnemyId);
                row.Enemy = enemy;
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