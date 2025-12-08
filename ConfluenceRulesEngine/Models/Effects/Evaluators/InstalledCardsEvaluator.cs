using ConfluenceRulesEngine.Models.Effects.Evaluators.Helpers;
using ConfluenceRulesEngine.Models.Shared;
using ConfluenceRulesEngine.Models.Zones;

using static ConfluenceRulesEngine.Models.Shared.Enums;

namespace ConfluenceRulesEngine.Models.Effects.Evaluators
{
    public class InstalledCardsEvaluator
        : IEvaluator<IEnumerable<CardId>>
    {
        public readonly CardType? Type;
        public readonly IEvaluator<IEnumerable<Socket>>? TargetSockets;

        public IEnumerable<CardId> Evaluate(GameContext context)
        {
            var sockets = context.Sockets;

            if (this.TargetSockets is not null)
            {
                sockets = this.TargetSockets
                    .Evaluate(context)
                    .ToList();
            }

            return sockets
                .Where(s => s.Cards.Count != 0)
                .Select(s => s.Cards.First())
                .Select(c => new CardId(c.ObjectId));
        }
    }
}
