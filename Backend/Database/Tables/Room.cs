using System;
using System.Data;

namespace Backend.Database.Tables {
    public class Room : ITable
{
    public string Id { get; set; }
    public string Title { get; set; }
    public int Rarity {get; set;}
    

    public List<string> GetCollumns()
    {
        throw new NotImplementedException();
    }

    public List<string> GetValues()
    {
        throw new NotImplementedException();
    }
}
}
