namespace ConfulenceRulesEngine.Experiments.Resolvers
{
    using ConfulenceRulesEngine.Experiments.Actions;
    using ConfulenceRulesEngine.Experiments.Selectors;
    using ConsoleApp1;

    public class ChoiceResolver
        : IResolver<ChoiceAction>
    {
        public void Resolve(ChoiceAction action, GameContext context)
        {
            var choices = action.Choices.Evaluate(context)?.ToList();

            if (choices is null)
            {
                return;
            }

            var targetPlayer = action.TargetPlayer.Evaluate(context);

            Console.WriteLine($"Player {targetPlayer} choose from:");

            foreach (var (choice, index) in choices.Select((c, i) => (c, i)))
            {
                Console.WriteLine($"{index}: {choice}");
            }

            if (!int.TryParse(Console.ReadLine(), out int input))
            {
                return;
            }
            else
            {
                context.Store["choice"] = new List<int>() { choices[input] };
            }

            context.ActionQueue.Add(new ActionLiteralSelector(action.Continuation));
        }
    }
}
