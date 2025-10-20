using ConfluenceRulesEngine.Models.Shared;

namespace ConfluenceRulesEngine.Models.Effects.Selectors.Operators.Numeric
{
    public class NumberLiteralEvaluator
        : IEvaluator<uint>
    {
        private readonly uint Value;

        public NumberLiteralEvaluator(uint value)
        {
            this.Value = value;
        }

        public uint Evaluate(GameContext context) => this.Value;
    }
}
