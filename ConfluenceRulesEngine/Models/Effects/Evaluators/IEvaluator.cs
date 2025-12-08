using ConfluenceRulesEngine.Models.Shared;

namespace ConfluenceRulesEngine.Models.Effects.Evaluators
{
    public interface IEvaluator<T>
    {
        public T Evaluate(GameContext context);
    }
}
