using ConfluenceRulesEngine.Models.Shared;

namespace ConfluenceRulesEngine.Models.Effects.Selectors
{
    public class ContextEvaluator<T>
        : IEvaluator<T>
    {
        private readonly string key;

        public ContextEvaluator(string key)
        {
            this.key = key;
        }

        public T Evaluate(GameContext context)
        {
            if (!context.Store.TryGetValue(key, out var storeValue))
            {
                return default!; //shutting up the compiler because this *can* actually be null just fine
            }
            else
            {
                return (T)storeValue;
            }
        }
    }
}
