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
        Enemy enemy = db.GetItem<Enemy>("ItemIdTest");
        
        Assert.Equal("ItemTitleTest", enemy.Title);
    }
}
