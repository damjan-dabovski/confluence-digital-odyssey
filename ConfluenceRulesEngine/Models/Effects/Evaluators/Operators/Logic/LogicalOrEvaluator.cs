using ConfluenceRulesEngine.Models.Shared;

namespace ConfluenceRulesEngine.Models.Effects.Selectors.Operators.Logic
{
    public class LogicalOrEvaluator
        : IEvaluator<bool>
    {
        public readonly IEvaluator<bool> Left;
        public readonly IEvaluator<bool> Right;

        public LogicalOrEvaluator(IEvaluator<bool> left, IEvaluator<bool> right)
        {
            this.Left = left;
            this.Right = right;
        }

        public bool Evaluate(GameContext context)
        {
            var leftValue = this.Left.Evaluate(context);
            var rightValue = this.Right.Evaluate(context);

            return leftValue && rightValue;
        }
    }
}
