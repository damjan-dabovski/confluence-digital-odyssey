using ConfluenceRulesEngine.Models.Effects.Evaluators;
using ConfluenceRulesEngine.Models.Zones;

namespace ConfluenceRulesEngine.Models.Shared
{
    public record GameContext(
        List<Socket> Sockets,
        //Dictionary<int, Card> CardObjects,
        //Dictionary<PlayerId, Player> Players,
        Dictionary<string, object> Store,
        // TODO use a deque (from library or in-house?) instead of list?
        List<IEvaluator<Action>> ActionQueue);
}
