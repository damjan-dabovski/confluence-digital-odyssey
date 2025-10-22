using ConfluenceRulesEngine.Helpers;
using ConfluenceRulesEngine.Models.Shared;
using ConfluenceRulesEngine.Models.Zones;

using static ConfluenceRulesEngine.Models.Shared.Enums;

namespace ConfluenceRulesEngine.Models.Effects.Selectors
{
    public class ZoneEvaluator
        : IEvaluator<IEnumerable<IZone>>
    {
        public readonly IEvaluator<PlayerId> Owner;
        public readonly ZoneType Type;

        public ZoneEvaluator(IEvaluator<PlayerId> owner, ZoneType type)
        {
            this.Owner = owner;
            this.Type = type;
        }

        public IEnumerable<IZone> Evaluate(GameContext context)
        {
            var ownerId = this.Owner.Evaluate(context);

            var owner = context.Players[ownerId];

            return this.Type switch
            {
                ZoneType.Hand => [owner.Hand],
                ZoneType.Deck => [owner.Deck],
                ZoneType.Trash => [owner.Trash],
                ZoneType.Board => SelectorHelpers.GetSocketsForPlayer(ownerId, SocketType.Any, context),
                _ => throw new InvalidOperationException($"Error evaluating ZoneSelector: no zone with enum value: {this.Type}")
            };
        }
    }
}
