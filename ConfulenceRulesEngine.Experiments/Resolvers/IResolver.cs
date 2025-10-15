namespace ConfulenceRulesEngine.Experiments.Resolvers
{
    using Action = Actions.Action;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using ConsoleApp1;

    public interface IResolver<T>
        where T: Action
    {
        public void Resolve(T action, GameContext context);
    }
}
