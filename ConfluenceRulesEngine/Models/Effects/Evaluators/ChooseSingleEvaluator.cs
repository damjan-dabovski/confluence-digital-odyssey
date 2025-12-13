using ConfluenceRulesEngine.Models.Core;
using ConfluenceRulesEngine.Models.Shared;

using static ConfluenceRulesEngine.Models.Shared.Enums;

namespace ConfluenceRulesEngine.Models.Effects.Evaluators
{
    public class ChooseSingleEvaluator<TObject>
        : IEvaluator<TObject?> where TObject : IChoosable
    {
        public readonly IEvaluator<Player> TargetPlayer;
        public readonly IEvaluator<IEnumerable<TObject>> Choices;

        public ChooseSingleEvaluator(IEvaluator<Player> targetPlayer, IEvaluator<IEnumerable<TObject>> choices)
        {
            this.TargetPlayer = targetPlayer;
            this.Choices = choices;
        }

        public TObject? Evaluate(GameContext context)
        {
            var choices = this.Choices.Evaluate(context)?.ToList();

            if (choices is null || choices.Count == 0)
            {
                return default;
            }

            var targetPlayer = TargetPlayer.Evaluate(context);

            var choicesMessage = "";

            for (var i = 0; i < choices.Count; i++)
            {
                choicesMessage += $"{i}: {choices[i].ToChoiceDisplayString()}";
            }
                
            targetPlayer.CommService.SendMessage(choicesMessage);

            var input = targetPlayer.CommService.GetInput();

            return choices[input];
        }
    }
}
