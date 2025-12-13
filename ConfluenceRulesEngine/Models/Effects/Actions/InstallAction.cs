using ConfluenceRulesEngine.Models.Core;
using ConfluenceRulesEngine.Models.Effects.Evaluators;
using ConfluenceRulesEngine.Models.Effects.Evaluators.Helpers;

namespace ConfluenceRulesEngine.Models.Effects.Actions
{
    public class InstallAction
        : Action
    {
        public readonly IEvaluator<Card?> ChosenCard;

        public readonly IEvaluator<Player> TargetPlayer;

        public readonly IEvaluator<CoordsFilter> AllowedSlots;

        public InstallAction(IEvaluator<Card?> chosenCard, IEvaluator<Player> targetPlayer, IEvaluator<CoordsFilter> allowedSlots, Action? continuation = null)
            : base(continuation)
        {
            this.ChosenCard = chosenCard;
            this.TargetPlayer = targetPlayer;
            this.AllowedSlots = allowedSlots;
        }
    }
}
