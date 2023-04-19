namespace GameEngine.Mechanics
{
    public interface IEntityProxy
    {
        T Get<T>();

        bool TryGet<T>(out T element);
    }
}