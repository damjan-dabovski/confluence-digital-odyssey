using ConsoleApp1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfulenceRulesEngine.Experiments.Selectors
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
            if (!context.Store.TryGetValue(key, out var storeValue))
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
