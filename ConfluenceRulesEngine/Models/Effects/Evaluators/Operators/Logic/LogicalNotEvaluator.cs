using ConfluenceRulesEngine.Models.Shared;

namespace ConfluenceRulesEngine.Models.Effects.Selectors.Operators.Logic
{
    public class LogicalNotEvaluator
        : IEvaluator<bool>
    {
        public readonly IEvaluator<bool> Operand;

        public LogicalNotEvaluator(IEvaluator<bool> operand)
        {
            this.Operand = operand;
        }

        public bool Evaluate(GameContext context)
        {
            var value = this.Operand.Evaluate(context);

            return !value;
        }
    }
}
