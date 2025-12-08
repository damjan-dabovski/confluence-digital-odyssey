using ConfluenceRulesEngine.Helpers;
using ConfluenceRulesEngine.Models.Effects.Evaluators.Helpers;
using ConfluenceRulesEngine.Models.Shared;
using ConfluenceRulesEngine.Models.Zones;

namespace ConfluenceRulesEngine.Models.Effects.Evaluators
{
    public class SocketsEvaluator
        : IEvaluator<IEnumerable<Socket>>
    {
        private readonly IEvaluator<CoordsFilter> Coords;

        public SocketsEvaluator(IEvaluator<CoordsFilter> coords)
        {
            this.Coords = coords;
        }

        public IEnumerable<Socket> Evaluate(GameContext context)
        {
            var sockets = context.Sockets;

            var coords = this.Coords.Evaluate(context);
            sockets = SelectorHelpers.FilterSocketsByCoords(sockets, coords);

            return sockets;
        }
    }
}
