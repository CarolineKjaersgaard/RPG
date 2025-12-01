using System;
using System.Data;

namespace Backend.Database.Tables {
    public class EnemyType : ITable
{
    public required string Id { get; set; }
    public required string Title { get; set; }
    public ICollection<Enemy>? Enemies {get; set;}

}
}
