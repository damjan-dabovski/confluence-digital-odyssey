using ConfluenceRulesEngine.Models.Shared;
using ConfluenceRulesEngine.Models.Zones;

using static ConfluenceRulesEngine.Models.Shared.Enums;

namespace ConfluenceRulesEngine.Helpers
{
    public static class SelectorHelpers
    {
        public static IEnumerable<IZone> GetSocketsForPlayer(PlayerId playerId, SocketType socketType, GameContext context)
        {
            var query = context.Board
                .Skip((int)playerId * 12)
                .Take(12);

            if (socketType != SocketType.Any)
            {
                query = query
                    .Skip((int)socketType)
                    .Select((socket, index) => new { Value = socket, Index = index })
                    .Where(indexedSocket => indexedSocket.Index % 2 == 0)
                    .Select(indexedSocket => indexedSocket.Value);
            }

            return query;
        }
    }
}
