using System;
using System.Data;

namespace Backend.Database.Tables {
    public class Enemy : ITable
{
    public required string Id { get; set; }
    public required string Title { get; set; }
    public required string Description {get; set;}
    public required string TypeId {get; set;}
    public required EnemyType Type {get; set;}
    public int Rarity { get; set; }
    public int Difficulty {get; set;}
    public int PackSize {get; set;}
    public required string WeaponId {get; set;}
    public required Item Weapon {get; set;}
    public string? EffectId {get; set;}
    public Effect? Effect {get; set;}
    public ICollection<EnemyInRoom>? Rooms {get; set;}
    public ICollection<LootOnEnemy>? Loot {get; set;}

}
}
