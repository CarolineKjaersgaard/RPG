using System;
using System.Data;

namespace Backend.Database.Tables {
    public class Item : ITable
{
    public string Id { get; set; }
    public string Title { get; set; }
    public string Description {get; set;}
    public int Rarity { get; set; }
    public bool isLootable {get; set;}
    public string EffectId {get; set;}
    public Effect Effect {get; set;}
    public string ItemTypeId {get; set;}
    public ItemType ItemType {get; set;}
    public List<string> TagIds {get; set;}
    public ICollection<Tag> Tags {get; set;}


    public List<string> GetCollumns()
    {
        return new List<string>
        {
            "Id", "Title" 
        };
    }
}
}
