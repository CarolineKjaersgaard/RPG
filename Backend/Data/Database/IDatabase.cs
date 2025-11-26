

public interface IDatabase
{
    public ITable GetItem<ITable>(string id);

    public List<ITable> GetItems<ITable>(string value, string collumn);

    public List<ITable> GetItems<ITable>(int value, string collumn);

    public List<ITable> GetItems<ITable>(int lowerValue, int upperValue, string collumn);
}