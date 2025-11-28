using System;
using System.Data;

namespace Backend.Database.Tables {
    public class Effect : ITable
{
    public required string Id { get; set; }
    public required string Title { get; set; }
    public required string Description {get; set;}
    public required string TypeId {get; set;}
    public required EffectType Type {get; set;}
    public int Amount {get; set;}
    public ICollection<Room>? Rooms {get; set;}
    public ICollection<Item>? Items {get; set;}
    public ICollection<Enemy>? Enemies {get; set;}

}
}
