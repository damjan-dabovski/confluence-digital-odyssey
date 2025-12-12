using ConfluenceRulesEngine.Models.Shared;

using static ConfluenceRulesEngine.Models.Shared.Enums;

namespace ConfluenceRulesEngine.Models.Effects.Evaluators
{
    public class ChooseSingleEvaluator<T>
        : IEvaluator<T?> where T:class
    {
        public readonly IEvaluator<PlayerId> TargetPlayer;
        public readonly IEvaluator<IEnumerable<T>> Choices;

        public ChooseSingleEvaluator(IEvaluator<PlayerId> targetPlayer, IEvaluator<IEnumerable<T>> choices)
        {
            this.TargetPlayer = targetPlayer;
            this.Choices = choices;
        }

        public T? Evaluate(GameContext context)
        {
            var choices = this.Choices.Evaluate(context)?.ToList();

            if (choices is null || choices.Count == 0)
            {
                return default;
            }

            var targetPlayerId = TargetPlayer.Evaluate(context);

            var targetPlayer = context.Players[targetPlayerId];

            int input = targetPlayer.CommService.GetInput();

            return choices[input];
        }
    }
}
