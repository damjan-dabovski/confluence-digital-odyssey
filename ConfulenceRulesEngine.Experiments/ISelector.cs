namespace ConsoleApp1
{
    public interface ISelector<T>
    {
        T? Evaluate(GameContext context);
    }
}
