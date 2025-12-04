using System;
using System.Data;

namespace Backend.Database.Tables {
    public class Item : ITable
{
    public string Id { get; set; } = "";
    public string Title { get; set; } = "";
    public string Description {get; set;} = "";
    public string TypeId {get; set;} = "";
    public int Rarity { get; set; }
    public bool isLootable {get; set;}
    public string? EffectId {get; set;}
    public ItemType? Type {get; set;}
    public Effect? Effect {get; set;}
    public ICollection<LootInRoom>? Rooms {get; set;}
    public ICollection<LootOnEnemy>? Enemies {get; set;}

}
}
