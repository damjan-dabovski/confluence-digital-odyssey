using static ConsoleApp1.Enums;

namespace ConsoleApp1
{
    public class ChoiceAction : Action
    {
        readonly ISelector TargetPlayer;
        readonly ISelector Choices;
        readonly Action Continuation;

        public ChoiceAction(ISelector targetPlayer, ISelector choices, Action continuation)
        {
            this.TargetPlayer = targetPlayer;
            this.Choices = choices;
            this.Continuation = continuation;
        }
    }
}
