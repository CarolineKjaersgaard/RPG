using System;
using System.Data;

namespace Backend.Database.Tables {
    public class RoomType : ITable
{
    public string Id { get; set; } = "";
    public string Title { get; set; } = "";
    public ICollection<Room>? Rooms {get; set;}

}
}
