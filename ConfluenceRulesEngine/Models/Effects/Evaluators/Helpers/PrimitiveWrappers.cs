using ConfluenceRulesEngine.Models.Shared;

namespace ConfluenceRulesEngine.Models.Effects.Evaluators.Helpers
{
    public record CardId(int Value)
        : IEvaluator<int>
    {
        public int Evaluate(GameContext context) => this.Value;

        public static implicit operator int(CardId cardId) => cardId.Value;
    }
}
