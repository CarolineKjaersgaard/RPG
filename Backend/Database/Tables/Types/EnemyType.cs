using System;
using System.Data;

namespace Backend.Database.Tables {
    public class EnemyType : ITable
{
    public string Id { get; set; } = "";
    public string Title { get; set; } = "";
    public ICollection<Enemy>? Enemies {get; set;}

}
}
