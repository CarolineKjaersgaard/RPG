using System;
using System.Data;

namespace Backend.Database.Tables {
    public class LootInRoom : ITable
{
    public string Id { get; set; } = "";
    public string ItemId { get; set; } = "";
    public string RoomId { get; set; } = "";
    public Item? Item {get; set;}
    public Room? Room {get; set;}

}
}
