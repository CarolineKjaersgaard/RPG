using System;
using System.Data;

namespace Backend.Database.Tables {
    public class EnemyInRoom : ITable
{
    public string Id { get; set; } = "";
    public string EnemyId { get; set; } = "";
    public string RoomId { get; set; } = "";
    public Enemy? Enemy {get; set;}
    public Room? Room {get; set;}

}
}
