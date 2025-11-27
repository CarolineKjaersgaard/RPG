using Backend.Database.Tables;

public class Room : ITable
{
    public string Id { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    public string Title { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

    public List<string> GetCollumns()
    {
        throw new NotImplementedException();
    }

    public List<string> GetValues()
    {
        throw new NotImplementedException();
    }
}