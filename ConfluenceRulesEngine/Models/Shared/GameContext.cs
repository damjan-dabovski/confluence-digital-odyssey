using ConfluenceRulesEngine.Models.Effects.Evaluators;
using ConfluenceRulesEngine.Models.Zones;

using Action = ConfluenceRulesEngine.Models.Effects.Actions.Action;

namespace ConfluenceRulesEngine.Models.Shared
{
    public record GameContext(
        List<Socket> Sockets,
        Dictionary<string, object> Store,
        List<IEvaluator<Action>> ActionQueue);
}
