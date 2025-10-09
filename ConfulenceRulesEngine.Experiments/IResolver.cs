using Action = ConsoleApp1.Action;
using ConsoleApp1;

namespace ConfulenceRulesEngine.Experiments
{
    public interface IResolver<T>
        where T: Action
    {
        public void Resolve(T action, GameContext context);
    }
}
