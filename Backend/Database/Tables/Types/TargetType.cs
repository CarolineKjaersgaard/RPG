using System;
using System.Data;

namespace Backend.Database.Tables {
    public class TargetType : ITable
{
    public required string Id { get; set; }
    public required string Title { get; set; }
    public ICollection<EffectType>? EffectTypes {get; set;}

}
}
