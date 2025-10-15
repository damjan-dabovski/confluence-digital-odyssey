namespace ConfulenceRulesEngine.Experiments.Actions
{
    using ConfulenceRulesEngine.Experiments.Selectors;
    using static ConsoleApp1.Enums;

    public class ChooseManyAction
        : Action
    {
        readonly ISelector<PlayerId> TargetPlayer;
        readonly ISelector<IEnumerable<int>> Choices;
        readonly Action Continuation;

        public ChooseManyAction(ISelector<PlayerId> targetPlayer, ISelector<IEnumerable<int>> choices, Action continuation)
        {
            TargetPlayer = targetPlayer;
            Choices = choices;
            Continuation = continuation;
        }
    }
}
