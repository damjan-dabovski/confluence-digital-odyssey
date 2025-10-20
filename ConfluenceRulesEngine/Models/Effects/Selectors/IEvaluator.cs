using ConfluenceRulesEngine.Models.Shared;

namespace ConfluenceRulesEngine.Models.Effects.Selectors
{
    public interface IEvaluator<T>
    {
        public T Evaluate(GameContext context);
    }
}
