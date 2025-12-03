using Backend.GameLogic.Entity;

namespace Backend.GameLogic.Player
{
    public interface IPlayer: IEntity
    {
        public (int, int) GetCoords();
        public void SetCoords(int x, int y);
    }
}
