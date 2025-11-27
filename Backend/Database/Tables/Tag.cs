using System;
using System.Data;

namespace Backend.Database.Tables {
    public class Tag : ITable
{
    public string Id { get; set; }
    public string Title { get; set; }

    public List<string> GetCollumns()
    {
        return new List<string>
        {
            Id, Title
        };
    }

    public List<string> GetValues()
    {
        return new List<string>
        {
          "Id", "Title"  
        };
    }
}
}
