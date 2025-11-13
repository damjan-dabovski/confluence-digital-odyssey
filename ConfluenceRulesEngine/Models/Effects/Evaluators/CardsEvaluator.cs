using ConfluenceRulesEngine.Models.Effects.Selectors;
using ConfluenceRulesEngine.Models.Shared;
using ConfluenceRulesEngine.Models.Zones;

using static ConfluenceRulesEngine.Models.Shared.Enums;

namespace ConfluenceRulesEngine.Models.Effects.Evaluators
{
    public class CardsEvaluator
        : IEvaluator<IEnumerable<int>>
    {
        public readonly CardType? Type;
        public readonly IEvaluator<IZone> Zone;

        public CardsEvaluator(IEvaluator<IZone> zone, CardType? type = null)
        {
            this.Type = type;
            this.Zone = zone;
        }

        public IEnumerable<int> Evaluate(GameContext context)
        {
            var zone = this.Zone.Evaluate(context);

            var cards = zone.Cards.ToList();

            if (this.Type is CardType type)
            {
                cards = [.. cards.Where(card => card.Type == this.Type)];
            }

            return cards.Select(c => c.ObjectId);
        }
    }
}
