using ConfluenceRulesEngine.Models.Shared;

using static ConfluenceRulesEngine.Models.Shared.Enums;

namespace ConfluenceRulesEngine.Models.Effects.Selectors.Operators.Numeric
{
    public class NumberArithmeticEvaluator
        : IEvaluator<int>
    {
        private readonly int Left;
        private readonly int Right;
        private readonly ArithmeticOperator Operator;

        public NumberArithmeticEvaluator(int left, int right, ArithmeticOperator op)
        {
            this.Left = left;
            this.Right = right;
            this.Operator = op;
        }

        public int Evaluate(GameContext context)
        {
            return this.Operator switch
            {
                ArithmeticOperator.Add => Left + Right,
                ArithmeticOperator.Subtract => Left - Right,
                ArithmeticOperator.Multiply => Left * Right,
                ArithmeticOperator.DivideRoundUp => Left % Right > 0 ? (Left / Right) + 1 : Left / Right,
                ArithmeticOperator.DivideRoundDown => Left / Right,
                _ => throw new InvalidOperationException("No such arithmetic operator exists")
            };
        }
    }
}
