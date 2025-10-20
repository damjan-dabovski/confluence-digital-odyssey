using ConfluenceRulesEngine.Models.Shared;

namespace ConfluenceRulesEngine.Models.Effects.Selectors.Operators
{
    public class SkipEvaluator<T>
        : IEvaluator<IEnumerable<T>>
    {
        private readonly IEvaluator<IEnumerable<T>> Source;
        private readonly int Amount;

        public SkipEvaluator(IEvaluator<IEnumerable<T>> source, int amount)
        {
            this.Source = source;
            this.Amount = amount;
        }

        public IEnumerable<T> Evaluate(GameContext context)
        {
            var list = this.Source.Evaluate(context);
            return list.Skip(this.Amount);
        }
    }
}
