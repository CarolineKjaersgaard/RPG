using System;
using System.Data;

namespace Backend.Database.Tables {
    public class EffectType : ITable
{
    public required string Id { get; set; }
    public required string Title { get; set; }
    public ICollection<Effect>? Effects {get; set;}

}
}
