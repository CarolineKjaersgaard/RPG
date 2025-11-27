namespace Backend.GameLogic.Room
{
    public interface IRoomFactory
    {
        public IRoom CreateRoom(ITable roomStats);
    }
}
