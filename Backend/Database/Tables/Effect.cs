using System;
using System.Data;

namespace Backend.Database.Tables {
    public class Effect : ITable
{
    public string Id { get; set; } = "";
    public string Title { get; set; } = "";
    public string Description {get; set;} = "";
    public string TypeId {get; set;} = "";
    public int Amount {get; set;}
    public bool isActive {get; set;}
    public bool isAoe {get; set;}
    public EffectType? Type {get; set;}
    public ICollection<Room>? Rooms {get; set;}
    public ICollection<Item>? Items {get; set;}
    public ICollection<Enemy>? Enemies {get; set;}

}
}
