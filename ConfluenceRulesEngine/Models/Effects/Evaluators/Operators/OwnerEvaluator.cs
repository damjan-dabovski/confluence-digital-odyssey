using ConfluenceRulesEngine.Models.Core;
using ConfluenceRulesEngine.Models.Shared;

namespace ConfluenceRulesEngine.Models.Effects.Evaluators.Operators
{
    public class OwnerEvaluator
        : IEvaluator<Player>
    {
        private readonly Card Card;

        public OwnerEvaluator(Card card)
        {
            this.Card = card;
        }

        public Player Evaluate(GameContext context) => Card.Owner;
    }
}
