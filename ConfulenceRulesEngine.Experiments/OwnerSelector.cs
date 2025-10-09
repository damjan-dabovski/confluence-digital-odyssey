using ConsoleApp1;

using static ConsoleApp1.Enums;

namespace ConfulenceRulesEngine.Experiments
{
    internal class OwnerSelector
        : ISelector<PlayerId>
    {
        private readonly int CardId;

        public OwnerSelector(int cardId)
        {
            CardId = cardId;
        }

        public PlayerId Evaluate(GameContext context)
        {
            return context.Cards[this.CardId].OwnerId;
        }
    }
}
