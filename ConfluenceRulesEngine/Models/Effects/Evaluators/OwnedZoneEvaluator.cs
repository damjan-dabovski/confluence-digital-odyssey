using ConfluenceRulesEngine.Models.Core;
using ConfluenceRulesEngine.Models.Shared;
using ConfluenceRulesEngine.Models.Zones;

using static ConfluenceRulesEngine.Models.Shared.Enums;

namespace ConfluenceRulesEngine.Models.Effects.Evaluators
{
    public class OwnedZoneEvaluator
        : IEvaluator<IZone>
    {
        public readonly IEvaluator<Player> Owner;
        public readonly ZoneType Type;

        public OwnedZoneEvaluator(IEvaluator<Player> owner, ZoneType type)
        {
            this.Owner = owner;
            this.Type = type;
        }

        public IZone Evaluate(GameContext context)
        {
            var owner = this.Owner.Evaluate(context);

            return this.Type switch
            {
                ZoneType.Hand => owner.Hand,
                ZoneType.Deck => owner.Deck,
                ZoneType.Trash => owner.Trash,
                _ => throw new InvalidOperationException($"ZoneEvaluator error: {this.Type} is not an owned zone (use a SocketEvaluator for sockets)")
            };
        }
    }
}
