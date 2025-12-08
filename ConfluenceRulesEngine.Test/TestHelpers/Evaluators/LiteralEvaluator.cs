namespace ConfluenceRulesEngine.Test.TestHelpers.Evaluators
{
    using ConfluenceRulesEngine.Models.Effects.Evaluators;
    using ConfluenceRulesEngine.Models.Shared;

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
