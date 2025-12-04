using System;
using System.Data;

namespace Backend.Database.Tables {
    public class ItemType : ITable
{
    public string Id { get; set; } = "";
    public string Title { get; set; } = "";
    public ICollection<Item>? Items {get; set;}

}
}
