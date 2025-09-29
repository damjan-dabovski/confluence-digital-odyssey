using ConfluenceRulesEngine.Models.Core;

using static ConfluenceRulesEngine.Models.Shared.Enums;

namespace ConfluenceRulesEngine.Models.Shared
{
    public record GameContext(
        Dictionary<int, Card> CardObjects,
        Dictionary<PlayerId, Player> Players);
}
