using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

using Backend.Database.Tables;
using Backend.Database.Handlers;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Backend.Database
{
    public class Database : IDatabase
    {
        public Context _context;
        public string _roomTypesCsv = "Database/Data/Types/RoomTypes.csv";
        public string _itemTypesCsv = "Database/Data/Types/ItemTypes.csv";
        public string _enemyTypesCsv = "Database/Data/Types/EnemyTypes.csv";
        public string _effectTypesCsv = "Database/Data/Types/EffectTypes.csv";
        public string _roomsCsv = "Database/Data/Rooms.csv";
        public string _itemsCsv = "Database/Data/Items.csv";
        public string _enemiesCsv = "Database/Data/Enemies.csv";
        public string _effectsCsv = "Database/Data/Effects.csv";
        public string _enemiesInRoomsCsv = "Database/Data/Connections/EnemiesInRooms.csv";
        public string _LootInRoomsCsv = "Database/Data/Connections/LootInRooms.csv";
        public string _LootOnEnemiesCsv = "Database/Data/Connections/LootOnEnemies.csv";
        public Database()
        {
            Console.WriteLine("*-*--------makes context----------*-*");
            var options = new DbContextOptionsBuilder<Context>()
                .UseSqlite("Data Source=database.db")
                .Options;
            _context = new Context(options);
            _context.Database.EnsureCreated();

            Parser parser = new Parser();
            Seeder seeder = new Seeder(_context, parser);

            Console.WriteLine("*-*--------calls seeder----------*-*");
            Console.WriteLine(Path.GetFullPath("Database/Data/Types/ItemTypes.csv"));
            seeder.SeedRoomTypes(_roomTypesCsv);
            seeder.SeedItemTypes(_itemTypesCsv);
            seeder.SeedEnemyTypes(_enemyTypesCsv);
            seeder.SeedEffectTypes(_effectTypesCsv);

            seeder.SeedRooms(_roomsCsv);
            seeder.SeedItems(_itemsCsv);
            seeder.SeedEnemies(_enemiesCsv);
            seeder.SeedEffects(_effectsCsv);

            seeder.SeedEnemiesInRooms(_enemiesInRoomsCsv);
            seeder.SeedLootInRooms(_LootInRoomsCsv);
            seeder.SeedLootOnEnemies(_LootOnEnemiesCsv);
        }
        public Table GetItem<Table>() where Table: class, ITable
        {    
            var item = _context.Set<Table>().OrderBy(e => EF.Functions.Random()).FirstOrDefault();
            if (item == null)
            {
                throw new InvalidOperationException($"No items found for type '{typeof(Table).Name}'.");
            }
            return item;
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
        public List<Table> GetItems<Table>() where Table: class, ITable
        {
            return _context.Set<Table>().ToList();
        }

        public List<Table> GetItems<Table>(object value, string column) where Table : class, ITable
        {
            var parameter = Expression.Parameter(typeof(Table), "entity");
            var property = Expression.Property(parameter, column);
            var constant = Expression.Constant(value);
            var equality = Expression.Equal(property, constant);
            var parameterInColumnIsValue = Expression.Lambda<Func<Table, bool>>(equality, parameter);

            return _context.Set<Table>().Where(parameterInColumnIsValue).ToList();
        }

        public List<Table> GetItems<Table>(int lowerValue, int upperValue, string column) where Table: class, ITable
        {
            var parameter = Expression.Parameter(typeof(Table), "entity");
            var property = Expression.Property(parameter, column);
            var lowerConstant = Expression.Constant(lowerValue);
            var upperConstant = Expression.Constant(upperValue);
            var greaterThanOrEqual = Expression.GreaterThanOrEqual(property, lowerConstant);
            var lessThanOrEqual = Expression.LessThanOrEqual(property, upperConstant);
            var inRange = Expression.AndAlso(greaterThanOrEqual, lessThanOrEqual);
            var parameterInColumnIsBetweenValues = Expression.Lambda<Func<Table, bool>>(inRange, parameter);

            return _context.Set<Table>().Where(parameterInColumnIsBetweenValues).ToList();
        }
    }
}
