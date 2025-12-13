using ConfluenceRulesEngine.Models.Core;
using ConfluenceRulesEngine.Models.Effects.Evaluators.Helpers;
using ConfluenceRulesEngine.Models.Shared;
using ConfluenceRulesEngine.Models.Zones;

using static ConfluenceRulesEngine.Models.Shared.Enums;

namespace ConfluenceRulesEngine.Models.Effects.Evaluators
{
    public class NonInstalledCardsEvaluator
        : IEvaluator<IEnumerable<Card>>
    {
        public readonly CardType? Type;
        public readonly IEvaluator<IZone> Zone;

        public NonInstalledCardsEvaluator(IEvaluator<IZone> zone, CardType? type = null)
        {
            this.Type = type;
            this.Zone = zone;
        }

        public IEnumerable<Card> Evaluate(GameContext context)
        {
            var zone = this.Zone.Evaluate(context);

            var cards = zone.Cards.ToList();

            if (this.Type is CardType type)
            {
                cards = [.. cards.Where(card => card.Type == this.Type)];
            }

            return cards;
        }
    }
}
