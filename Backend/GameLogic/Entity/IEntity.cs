namespace Backend.GameLogic.Entity
{
    public interface IEntity
    {
        public bool ExecuteEffect(string effect, IEntity target);
    }
}
