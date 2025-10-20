using ConfluenceRulesEngine.Models.Shared;

namespace ConfluenceRulesEngine.Models.Effects.Selectors.Operators
{
    public class UnionEvaluator<T>
        : IEvaluator<IEnumerable<T>>
    {
        private readonly IEvaluator<IEnumerable<T>> Left;
        private readonly IEvaluator<IEnumerable<T>> Right;

        public UnionEvaluator(IEvaluator<IEnumerable<T>> left, IEvaluator<IEnumerable<T>> right)
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
