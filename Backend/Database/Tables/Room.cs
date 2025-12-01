using System;
using System.Data;

namespace Backend.Database.Tables {
    public class Room : ITable
{
    public required string Id { get; set; }
    public required string Title { get; set; }
    public required string Description {get; set;}
    public required string TypeId {get; set;}
    public required RoomType Type {get; set;}
    public int MinDoors {get; set;}
    public int MaxDoors {get; set;}
    public int Rarity { get; set; }
    public int Difficulty {get; set;}
    public string? EffectId {get; set;}
    public Effect? Effect {get; set;}
    public ICollection<LootInRoom>? Loot {get; set;}
    public ICollection<EnemyInRoom>? Enemies {get; set;}

}
}
