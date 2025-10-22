using ConfluenceRulesEngine.Models.Shared;

using static ConfluenceRulesEngine.Models.Shared.Enums;

namespace ConfluenceRulesEngine.Models.Effects.Selectors
{
    public class OwnerEvaluator
        : IEvaluator<PlayerId>
    {
        private readonly int CardId;

        public OwnerEvaluator(int cardId)
        {
            CardId = cardId;
        }

        public PlayerId Evaluate(GameContext context)
        {
            return context.CardObjects[CardId].OwnerId;
        }
    }
}
