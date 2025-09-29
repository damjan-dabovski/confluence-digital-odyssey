using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class ContextSelector
        : ISelector
    {
        //TODO this is wrong since 1) it needs to be the temporary ExecutionContext and 2) we can't have a reference
        // to that at 'compile' time anyway
        //private readonly GameContext context;
        private readonly string key;

        public ContextSelector(string key)
        {
            this.key = key;
        }

        public IEnumerable<int> Evaluate(GameContext context) => context.Store[this.key];
    }
}
