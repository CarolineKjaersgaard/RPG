using System;
using System.Data;

namespace Backend.Database.Tables {
    public class Effect : ITable
{
    public string Id { get; set; }
    public string Title { get; set; }
    public string Description {get; set;}
    public bool isActive {get; set;}
    public bool isAoe {get; set;}
    public int Amount {get; set;}
    public string TargetTypeId {get; set;}
    public TargetType TargetType {get; set;}
    public string EffectTypeId {get; set;}
    public EffectType EffectType {get; set;}


    public List<string> GetCollumns()
    {
        return new List<string>
        {
            "Id", "Title", "Description", "isActive", "isAoe"
        };
    }
}
}
