using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

using Backend.Database.Tables;
using Backend.Database.Handlers;

namespace Backend.Database
{
    public class Database : IDatabase
    {
        public Context _context;
        public Database()
        {
            var options = new DbContextOptionsBuilder<Context>()
                .UseSqlite("Data Source=database.db")
                .Options;
            _context = new Context(options);
            _context.Database.EnsureCreated();

            Parser parser = new Parser();
            Seeder seeder = new Seeder(_context, parser);
            seeder.SeedRooms("Data/Rooms.csv");
            seeder.SeedItems("Data/Items.csv");
            seeder.SeedEnemies("Data/Enemies.csv");
            seeder.SeedEffects("Data/Effects.csv");
            seeder.SeedRoomTypes("Data/RoomTypes.csv");
            seeder.SeedItemTypes("Data/ItemTypes.csv");
            seeder.SeedEnemyTypes("Data/EnemyTypes.csv");
            seeder.SeedEffectTypes("Data/EffectTypes.csv");
            seeder.SeedEnemiesInRooms("Data/EnemiesInRooms.csv");
            seeder.SeedLootInRooms("Data/LootInRooms.csv");
            seeder.SeedLootOnEnemies("Data/LootOnEnemies.csv");
        }
        public Table GetItem<Table>(string id) where Table: class, ITable
        {
            Table? item = _context.Set<Table>().Find(id);
            if (item == null)
            {
                throw new KeyNotFoundException($"Item of type '{typeof(Table).Name}' with Id '{id}' was not found.");
            }
            return item;
        }

        public List<Table> GetItems<Table>(object value, string column) where Table : class, ITable
        {
            var parameter = Expression.Parameter(typeof(Table), "entity");
            var property = Expression.Property(parameter, column);
            var constant = Expression.Constant(value);
            var equality = Expression.Equal(property, constant);
            var lambda = Expression.Lambda<Func<Table, bool>>(equality, parameter);

            return _context.Set<Table>()
                .Where(lambda)
                .ToList();
        }

        public List<Table> GetItems<Table>(int lowerValue, int upperValue, string collumn) where Table: class, ITable
        {
            return new List<Table>();
        }
    }
}
