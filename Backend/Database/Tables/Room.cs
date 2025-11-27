using System;
using System.Data;

namespace Backend.Database.Tables {
    public class Room : ITable
{
    public required string Id { get; set; }
    public required string Title { get; set; }
    public required string Description {get; set;}
    public int Doors {get; set;}
    public int Rarity { get; set; }
    public int Difficulty {get; set;}
    public string? EffectId {get; set;}
    public Effect? Effect {get; set;}
    public List<string>? TagIds {get; set;}
    public ICollection<Tag>? Tags {get; set;}


    public List<string> GetCollumns()
    {
        return new List<string>
        {
            "Id", "Title" 
        };
    }
}
}
