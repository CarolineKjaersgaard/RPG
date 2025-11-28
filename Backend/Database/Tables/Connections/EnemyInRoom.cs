using System;
using System.Data;

namespace Backend.Database.Tables {
    public class EnemyInRoom : ITable
{
    public required string Id { get; set; }
    public required string EnemyId { get; set; }
    public required Enemy Enemy {get; set;}
    public required string RoomId { get; set; }
    public required Room Room {get; set;}

}
}
