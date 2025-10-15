using static ConsoleApp1.Enums;

namespace ConsoleApp1
{
    public class ChoiceSelector
        : ISelector<IEnumerable<int>>
    {
        public readonly ISelector<PlayerId> TargetPlayer;
        public readonly ISelector<IEnumerable<int>> Choices;

        public ChoiceSelector(ISelector<PlayerId> targetPlayer, ISelector<IEnumerable<int>> choices)
        {
            TargetPlayer = targetPlayer;
            Choices = choices;
        }

        public IEnumerable<int>? Evaluate(GameContext context)
        {
            var choices = Choices.Evaluate(context)?.ToList();

            if (choices is null)
            {
                return [];
            }

            var targetPlayer = TargetPlayer.Evaluate(context);

            Console.WriteLine($"Player {targetPlayer} choose from:");

            foreach (var (choice, index) in choices.Select((c, i) => (c, i)))
            {
                Console.WriteLine($"{index}: {choice}");
            }

            if (!int.TryParse(Console.ReadLine(), out int input))
            {
                return [];
            }
            else
            {
                return ([choices[input]]);
            }
        }
    }
}
