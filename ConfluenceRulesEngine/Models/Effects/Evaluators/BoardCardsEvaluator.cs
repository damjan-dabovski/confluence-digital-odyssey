using ConfluenceRulesEngine.Helpers;
using ConfluenceRulesEngine.Models.Effects.Evaluators.Helpers;
using ConfluenceRulesEngine.Models.Effects.Selectors;
using ConfluenceRulesEngine.Models.Shared;

using static ConfluenceRulesEngine.Models.Shared.Enums;

namespace ConfluenceRulesEngine.Models.Effects.Evaluators
{
    public class BoardCardsEvaluator
        : IEvaluator<IEnumerable<int>>
    {
        public readonly CardType? Type;
        public readonly IEvaluator<CoordsFilter>? Coords;

        public BoardCardsEvaluator(CardType? type, IEvaluator<CoordsFilter>? coords)
        {
            this.Type = type;
            this.Coords = coords;
        }

        public IEnumerable<int> Evaluate(GameContext context)
        {
            var sockets = context.Sockets;

            if (this.Coords is not null)
            {
                var coords = this.Coords.Evaluate(context);
                sockets = SelectorHelpers.FilterSocketsByCoords(sockets, coords);
            }

            return sockets
                .Where(s => s.Cards.Count != 0)
                .Select(s => s.Cards.First())
                .Select(c => c.ObjectId);
        }
    }
}
