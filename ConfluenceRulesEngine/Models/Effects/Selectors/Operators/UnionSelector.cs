using ConfluenceRulesEngine.Models.Shared;

namespace ConfluenceRulesEngine.Models.Effects.Selectors.Operators
{
    public class UnionSelector<T>
        : ISelector<IEnumerable<T>>
    {
        private readonly ISelector<IEnumerable<T>> Left;
        private readonly ISelector<IEnumerable<T>> Right;

        public UnionSelector(ISelector<IEnumerable<T>> left, ISelector<IEnumerable<T>> right)
        {
            this.Left = left;
            this.Right = right;
        }

        public IEnumerable<T> Evaluate(GameContext context)
        {
            var leftResult = this.Left.Evaluate(context).ToList();
            var rightResult = this.Right.Evaluate(context).ToList();

            return leftResult.Union(rightResult);
        }
    }
}
