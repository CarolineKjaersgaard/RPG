using System;
using System.Data;

namespace Backend.Database.Tables {
    public class EffectType : ITable
{
    public string Id { get; set; } = "";
    public string Title { get; set; } = "";
    public ICollection<Effect>? Effects {get; set;}

}
}
