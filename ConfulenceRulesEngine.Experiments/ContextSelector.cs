namespace ConsoleApp1
{
    public class ContextSelector<T>
        : ISelector<T> // we can really put everything in the context, so this needs to be as loosely typed as possible; the individual resolvers that evaluate this need to be able to make sure things cast successfully
    {
        private readonly string key;

        public ContextSelector(string key)
        {
            this.key = key;
        }

        public T? Evaluate(GameContext context)
        {
            if (!context.Store.TryGetValue(this.key, out var storeValue))
            {
                return default;
            }
            else
            {
                return (T)storeValue;
            }
        }
    }
}
