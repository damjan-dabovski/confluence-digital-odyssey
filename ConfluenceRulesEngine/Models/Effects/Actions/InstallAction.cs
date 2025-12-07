using ConfluenceRulesEngine.Models.Effects.Evaluators.Helpers;
using ConfluenceRulesEngine.Models.Effects.Selectors;

using static ConfluenceRulesEngine.Models.Shared.Enums;

namespace ConfluenceRulesEngine.Models.Effects.Actions
{
    public class InstallAction
        : Action
    {
        public readonly IEvaluator<int?> ChosenCard;

        public readonly IEvaluator<PlayerId> TargetPlayer;

        public readonly IEvaluator<CoordsFilter> AllowedSlots;

        public InstallAction(IEvaluator<int?> chosenCard, IEvaluator<PlayerId> targetPlayer, IEvaluator<CoordsFilter> allowedSlots, Action? continuation = null)
            : base(continuation)
        {
            this.ChosenCard = chosenCard;
            this.TargetPlayer = targetPlayer;
            this.AllowedSlots = allowedSlots;
        }
    }
}
