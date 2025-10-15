using ConfulenceRulesEngine.Experiments.Selectors;
using static ConsoleApp1.Enums;

namespace ConfulenceRulesEngine.Experiments.Actions
{
    public class ChoiceAction : Action
    {
        public readonly ISelector<PlayerId> TargetPlayer;
        public readonly ISelector<IEnumerable<int>> Choices;
        public readonly Action Continuation;

        public ChoiceAction(ISelector<PlayerId> targetPlayer, ISelector<IEnumerable<int>> choices, Action continuation)
        {
            TargetPlayer = targetPlayer;
            Choices = choices;
            Continuation = continuation;
        }
    }
}
