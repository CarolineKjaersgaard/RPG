

public interface IDatabase
{
    public Itable GetItem<Itable>(string name);

    public List<Itable> GetItems<Itable>(string value, string collumn);

    public List<Itable> GetItems<Itable>(int value, string collumn);

    public List<Itable> GetItems<Itable>(int lowerValue, int upperValue, string collumn);
}