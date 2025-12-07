using ConfluenceRulesEngine.Models.Shared;

using static ConfluenceRulesEngine.Models.Shared.Enums;

namespace ConfluenceRulesEngine.Models.Effects.Selectors
{
    public class ChooseSingleEvaluator
        : IEvaluator<int?>
    {
        public readonly IEvaluator<PlayerId> TargetPlayer;
        public readonly IEvaluator<IEnumerable<int>> Choices;

        public ChooseSingleEvaluator(IEvaluator<PlayerId> targetPlayer, IEvaluator<IEnumerable<int>> choices)
        {
            this.TargetPlayer = targetPlayer;
            this.Choices = choices;
        }

        public int? Evaluate(GameContext context)
        {
            var choices = this.Choices.Evaluate(context)?.ToList();

            if (choices is null || choices.Count == 0)
            {
                return null; // we're returning no value instead of any valid int, because technically
                            // nothing *should* be valid in this case; if this evaluated to a list instead
                            // (which it did, no clue why though), it would return an empty list here
            }

            var targetPlayer = TargetPlayer.Evaluate(context);

            // TODO this is just placeholder code until a more abstract communication service or similar
            // is implemented for managing user input (also consider that it needs to be potentially used by AI players)

            Console.WriteLine($"Player {targetPlayer} choose from:");

            foreach (var (choice, index) in choices.Select((c, i) => (c, i)))
            {
                Console.WriteLine($"{index}: {choice}");
            }

            if (!int.TryParse(Console.ReadLine(), out var input))
            {
                return null;
            }
            else
            {
                return (choices[input]);
            }

            // TODO!IMPORTANT this needs to use an abstract comm service to enable any kind of unit testing
            // to be performed on things that would require player input at some point
        }
    }
}
