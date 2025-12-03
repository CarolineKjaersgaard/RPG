using System;
using System.Data;

namespace Backend.Database.Tables {
    public class RoomType : ITable
{
    public required string RoomTypeId { get; set; }
    public required string Title { get; set; }
    public ICollection<Room>? Rooms {get; set;}

}
}
