using System;
using System.Data;

namespace Backend.Database.Tables {
    public class LootInRoom : ITable
{
    public required string Id { get; set; }
    public required string ItemId { get; set; }
    public required string RoomId { get; set; }
    public required Item Item {get; set;}
    public required Room Room {get; set;}

}
}
