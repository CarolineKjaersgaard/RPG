using System;
using Backend;
using Backend.Database;
using Backend.Database.Tables;
namespace DungeonsAndTesting;

public class DatabaseTest
{
    [Fact]
    public void GetItemFromId_ReturnsItem()
    {
        Database db = new Database();
        Enemy enemy = db.GetItem<Enemy>("ExplodingAlien");
        
        Assert.Equal("Alien shaped like a bomb", enemy.Title);
    }
}
