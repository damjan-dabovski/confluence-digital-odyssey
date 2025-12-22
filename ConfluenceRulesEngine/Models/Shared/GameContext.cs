using ConfluenceRulesEngine.Models.Effects.Evaluators;
using ConfluenceRulesEngine.Models.Zones;

using Nito.Collections;

using Action = ConfluenceRulesEngine.Models.Effects.Actions.Action;

namespace ConfluenceRulesEngine.Models.Shared
{
    public record GameContext(
        List<Socket> Sockets,
        Dictionary<string, object> Store,
        Deque<IEvaluator<Action>> ActionQueue);
}
