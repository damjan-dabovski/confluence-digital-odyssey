using ConfluenceRulesEngine.Models.Shared;

namespace ConfluenceRulesEngine.Models.Effects.Selectors.Operators
{
    public class NumberLiteralSelector
        : ISelector<uint>
    {
        private readonly uint Value;

        public NumberLiteralSelector(uint value)
        {
            this.Value = value;
        }

        public uint Evaluate(GameContext context) => this.Value;
    }
}
