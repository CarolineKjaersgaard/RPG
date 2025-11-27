using System;

namespace RPG.Database {
    public interface ITable 
{
    public string Id { get; set; }
    public string Title { get; set; }
    public List<string> GetValues();
    public List<string> GetCollumns();
}
}

