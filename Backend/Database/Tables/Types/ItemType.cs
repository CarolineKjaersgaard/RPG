using System;
using System.Data;

namespace Backend.Database.Tables {
    public class ItemType : ITable
{
    public required string Id { get; set; }
    public required string Title { get; set; }
    public ICollection<Item>? Items {get; set;}

}
}
