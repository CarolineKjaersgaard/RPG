using System;
using System.Data;

namespace Backend.Database.Tables {
    public class Effect : ITable
{
    public required string Id { get; set; }
    public required string Title { get; set; }
    public required string Description {get; set;}
    public bool isActive {get; set;}
    public bool isAoe {get; set;}
    public int Amount {get; set;}
    public required string TargetTypeId {get; set;}
    public required TargetType TargetType {get; set;}
    public required string EffectTypeId {get; set;}
    public required EffectType EffectType {get; set;}


    public List<string> GetCollumns()
    {
        return new List<string>
        {
            "Id", "Title", "Description", "isActive", "isAoe"
        };
    }
}
}
