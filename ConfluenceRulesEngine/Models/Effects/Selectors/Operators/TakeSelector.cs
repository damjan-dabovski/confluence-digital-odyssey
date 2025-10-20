using ConfluenceRulesEngine.Models.Shared;

namespace ConfluenceRulesEngine.Models.Effects.Selectors.Operators
{
    public class TakeSelector<T>
        : ISelector<IEnumerable<T>>
    {
        private readonly ISelector<IEnumerable<T>> Source;
        private readonly int Amount;

        public TakeSelector(ISelector<IEnumerable<T>> source, int amount)
        {
            this.Source = source;
            this.Amount = amount;
        }

        public IEnumerable<T> Evaluate(GameContext context)
        {
            var list = this.Source.Evaluate(context);
            return list.Take(this.Amount);
        }
    }
}
