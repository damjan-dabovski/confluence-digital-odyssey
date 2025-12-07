using ConfluenceRulesEngine.Helpers;
using ConfluenceRulesEngine.Models.Effects.Evaluators.Helpers;
using ConfluenceRulesEngine.Models.Effects.Selectors;
using ConfluenceRulesEngine.Models.Shared;

namespace ConfluenceRulesEngine.Models.Effects.Evaluators
{
    public class SocketsEvaluator
        : IEvaluator<IEnumerable<int>>
    {
        private readonly IEvaluator<CoordsFilter> Coords;

        public SocketsEvaluator(IEvaluator<CoordsFilter> coords)
        {
            this.Coords = coords;
        }

        public IEnumerable<int> Evaluate(GameContext context)
        {
            var sockets = context.Sockets;

            var coords = this.Coords.Evaluate(context);
            sockets = SelectorHelpers.FilterSocketsByCoords(sockets, coords);

            return sockets.Select(s => s.Id);
        }
    }
}
