using ConfluenceRulesEngine.Models.Shared;

using static ConfluenceRulesEngine.Models.Shared.Enums;

namespace ConfluenceRulesEngine.Models.Effects.Selectors
{
    public class OwnerSelector
        : ISelector<PlayerId>
    {
        private readonly int CardId;

        public OwnerSelector(int cardId)
        {
            CardId = cardId;
        }

        public PlayerId Evaluate(GameContext context)
        {
            return context.CardObjects[CardId].OwnerId;
        }
    }
}
