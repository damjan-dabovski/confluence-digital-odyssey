using static ConsoleApp1.Enums;

namespace ConsoleApp1
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
