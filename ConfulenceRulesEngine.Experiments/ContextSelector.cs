using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class ContextSelector
        : ISelector<object> // we can really put everything in the context, so this needs to be as loosely typed as possible; the individual resolvers that evaluate this need to be able to make sure things cast successfully
    {
        private readonly string key;

        public ContextSelector(string key)
        {
            this.key = key;
        }

        public object Evaluate(GameContext context) => context.Store[this.key];
    }
}
