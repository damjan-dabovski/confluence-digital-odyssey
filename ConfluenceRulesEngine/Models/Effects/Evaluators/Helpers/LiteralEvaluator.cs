using ConfluenceRulesEngine.Models.Shared;

namespace ConfluenceRulesEngine.Models.Effects.Evaluators.Helpers
{
    public class LiteralEvaluator<T>
        : IEvaluator<T>
    {
        public readonly T Value;

        public LiteralEvaluator(T value)
        {
            Value = value;
        }

        public T Evaluate(GameContext context) => this.Value;
    }
}
