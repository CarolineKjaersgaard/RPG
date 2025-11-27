using System;

namespace Backend.Database.Tables
{
    public interface ITable 
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public List<string> GetCollumns();
    }
}

