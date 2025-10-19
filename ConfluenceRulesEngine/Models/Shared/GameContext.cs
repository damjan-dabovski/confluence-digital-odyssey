using ConfluenceRulesEngine.Models.Core;
using ConfluenceRulesEngine.Models.Zones;

using static ConfluenceRulesEngine.Models.Shared.Enums;

namespace ConfluenceRulesEngine.Models.Shared
{
    public record GameContext(
        IEnumerable<IZone> Board,
        Dictionary<int, Card> CardObjects,
        Dictionary<PlayerId, Player> Players,
        Dictionary<string, object> Store);
}
