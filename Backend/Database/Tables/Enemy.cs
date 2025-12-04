using System;
using System.Data;

namespace Backend.Database.Tables {
    public class Enemy : ITable
{
    public string Id { get; set; } = "";
    public string Title { get; set; } = "";
    public string Description {get; set;} = "";
    public string TypeId {get; set;} = "";
    public int Rarity { get; set; }
    public int Difficulty {get; set;}
    public int PackSize {get; set;}
    public string WeaponId {get; set;} = "";
    public string? EffectId {get; set;}
    public EnemyType? Type {get; set;}
    public Item? Weapon {get; set;}
    public Effect? Effect {get; set;}
    public ICollection<EnemyInRoom>? Rooms {get; set;}
    public ICollection<LootOnEnemy>? Loot {get; set;}

}
}
