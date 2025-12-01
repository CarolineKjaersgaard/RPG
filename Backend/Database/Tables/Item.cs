using System;
using System.Data;

namespace Backend.Database.Tables {
    public class Item : ITable
{
    public required string Id { get; set; }
    public required string Title { get; set; }
    public required string Description {get; set;}
    public required string TypeId {get; set;}
    public required ItemType Type {get; set;}
    public int Rarity { get; set; }
    public bool isLootable {get; set;}
    public string? EffectId {get; set;}
    public Effect? Effect {get; set;}
    public ICollection<LootInRoom>? Rooms {get; set;}
    public ICollection<LootOnEnemy>? Enemies {get; set;}

}
}
