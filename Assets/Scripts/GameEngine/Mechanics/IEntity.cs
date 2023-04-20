namespace GameEngine.Mechanics
{
    public interface IEntity
    {
        T Get<T>();

        bool TryGet<T>(out T element);
    }
}