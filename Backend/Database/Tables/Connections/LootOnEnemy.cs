using System;
using System.Data;

namespace Backend.Database.Tables {
    public class LootOnEnemy : ITable
{
    public string Id { get; set; } = "";
    public string EnemyId {get; set;} = "";
    public string ItemId {get; set;} = "";
    public Enemy? Enemy {get; set;}
    public Item? Item {get; set;}

}
}
