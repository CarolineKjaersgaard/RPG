using System;
using System.Data;

namespace Backend.Database.Tables {
    public class LootOnEnemy : ITable
{
    public required string Id { get; set; }
    public required string EnemyId {get; set;}
    public required string ItemId {get; set;}
    public required Enemy Enemy {get; set;}
    public required Item Item {get; set;}

}
}
