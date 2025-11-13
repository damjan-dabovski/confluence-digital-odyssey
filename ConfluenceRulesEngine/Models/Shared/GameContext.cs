using ConfluenceRulesEngine.Models.Core;
using ConfluenceRulesEngine.Models.Effects.Selectors;
using ConfluenceRulesEngine.Models.Zones;

using static ConfluenceRulesEngine.Models.Shared.Enums;

namespace ConfluenceRulesEngine.Models.Shared
{
    public record GameContext(
        IEnumerable<Socket> Sockets,
        Dictionary<int, Card> CardObjects,
        Dictionary<PlayerId, Player> Players,
        Dictionary<string, object> Store,
        // TODO use a deque (from library or in-house?) instead of list?
        List<IEvaluator<Action>> ActionQueue);
}
