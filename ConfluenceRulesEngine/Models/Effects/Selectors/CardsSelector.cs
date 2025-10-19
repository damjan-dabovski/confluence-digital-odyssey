using ConfluenceRulesEngine.Models.Shared;
using ConfluenceRulesEngine.Models.Zones;

using static ConfluenceRulesEngine.Models.Shared.Enums;

namespace ConfluenceRulesEngine.Models.Effects.Selectors
{
    public class CardsSelector
        : ISelector<IEnumerable<int>>
    {
        public readonly CardType? Type;
        public readonly ISelector<IEnumerable<IZone>> Zone;
        public readonly ISelector<bool>? PositionPredicate;

        public CardsSelector(ISelector<IEnumerable<IZone>> zone, CardType? type = null, ISelector<bool>? positionPredicate = null)
        {
            this.Type = type;
            this.Zone = zone;
            this.PositionPredicate = positionPredicate;
        }

        public IEnumerable<int> Evaluate(GameContext context)
        {
            var zones = this.Zone.Evaluate(context).ToList();

            // TODO we need to be able to filter by position
            // does that make any sense when it's a union of multiple zones, or only for a single zone?
            // we need things like 'all cards in slot 1'

            var cards = zones.SelectMany(zone => zone.Cards);

            if (this.Type is CardType type)
            {
                cards = cards.Where(card => card.Type == this.Type);
            }

            throw new NotImplementedException("Fuck, solve the TODO first");
        }
    }
}
