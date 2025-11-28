using ConfluenceRulesEngine.Models.Effects.Selectors;

using static ConfluenceRulesEngine.Models.Shared.Enums;

namespace ConfluenceRulesEngine.Models.Effects.Actions
{
    public class InstallAction
        : Action
    {
        public readonly IEvaluator<int> ChosenCard;

        public readonly IEvaluator<PlayerId> TargetPlayer;

        public readonly IEvaluator<int>? SlotOverride;

        public readonly CardType? TypeFilter;

        public InstallAction(IEvaluator<int> chosenCard, IEvaluator<PlayerId> targetPlayer, Action? continuation = null)
            : base(continuation)
        {
            this.ChosenCard = chosenCard;
            this.TargetPlayer = targetPlayer;
        }
    }
}
