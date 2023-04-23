namespace Components
{
    public interface IValue<out T>
    {
        T Value { get; }
    }
}