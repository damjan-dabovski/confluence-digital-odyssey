using ConfluenceRulesEngine.Models.Shared;

using static ConfluenceRulesEngine.Models.Shared.Enums;

namespace ConfluenceRulesEngine.Models.Effects.Selectors.Operators
{
    public class NumberArithmeticSelector
        : ISelector<uint>
    {
        private readonly uint Left;
        private readonly uint Right;
        private readonly ArithmeticOperator Operator;

        public NumberArithmeticSelector(uint left, uint right, ArithmeticOperator op)
        {
            this.Left = left;
            this.Right = right;
            this.Operator = op;
        }

        public uint Evaluate(GameContext context)
        {
            return this.Operator switch
            {
                ArithmeticOperator.Add => Left + Right,
                ArithmeticOperator.Subtract => Left - Right,
                ArithmeticOperator.Multiply => Left * Right,
                ArithmeticOperator.DivideRoundUp => Left % Right > 0 ? (Left / Right) + 1 : (Left / Right),
                ArithmeticOperator.DivideRoundDown => Left / Right,
                _ => throw new InvalidOperationException("No such arithmetic operator exists")
            };
        }
    }
}
