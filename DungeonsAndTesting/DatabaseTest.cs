using System;
using Backend;
using Backend.Database;
using Backend.Database.Tables;
using Backend.Database.Handlers;
namespace DungeonsAndTesting;

public class DatabaseTest
{
    [Fact]
    public void Testing()
    {
        
var parser = new Parser();
var records = parser.Parse<EnemyType>("DataTest/Types/EnemyTypes.csv");
Console.WriteLine($"Parsed {records.Count} records");
Assert.Equal(1, records.Count);
    }

    [Fact]
    public void GetItemFromId_ReturnsItem()
    {
        Database db = new Database("DataTest/Rooms.csv", "DataTest/Items.csv",  "DataTest/Effects.csv", "DataTest/Enemies.csv", "DataTest/Types/EnemyTypes.csv","DataTest/Types/ItemTypes.csv","DataTest/Types/RoomTypes.csv","DataTest/Types/EffectTypes.csv",     "DataTest/Connections/LootInRooms.csv", "DataTest/Connections/LootOnEnemies.csv", "DataTest/Connections/EnemiesInRooms.csv");
        Enemy enemy = db.GetItem<Enemy>("EnemyIdTest");
        
        Assert.Equal("EnemyTitleTest", enemy.Title);
    }
}
