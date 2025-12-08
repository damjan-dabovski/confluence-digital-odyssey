using ConfluenceRulesEngine.Models.Effects.Evaluators;
using ConfluenceRulesEngine.Models.Effects.Evaluators.Helpers;

using static ConfluenceRulesEngine.Models.Shared.Enums;

namespace ConfluenceRulesEngine.Models.Effects.Actions
{
    public class InstallAction
        : Action
    {
        public readonly IEvaluator<CardId?> ChosenCard;

        public readonly IEvaluator<PlayerId> TargetPlayer;

        public readonly IEvaluator<CoordsFilter> AllowedSlots;

        public InstallAction(IEvaluator<CardId?> chosenCard, IEvaluator<PlayerId> targetPlayer, IEvaluator<CoordsFilter> allowedSlots, Action? continuation = null)
            : base(continuation)
        {
            this.ChosenCard = chosenCard;
            this.TargetPlayer = targetPlayer;
            this.AllowedSlots = allowedSlots;
        }
    }
}
