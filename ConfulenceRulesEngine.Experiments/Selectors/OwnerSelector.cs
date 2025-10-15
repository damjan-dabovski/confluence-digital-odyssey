namespace ConfulenceRulesEngine.Experiments.Selectors
{
    using ConsoleApp1;
    using static ConsoleApp1.Enums;

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
            return context.Cards[CardId].OwnerId;
        }
    }
}
