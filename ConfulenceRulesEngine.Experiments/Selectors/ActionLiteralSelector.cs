namespace ConfulenceRulesEngine.Experiments.Selectors
{
    using ConfulenceRulesEngine.Experiments.Actions;
    using ConsoleApp1;

    public class ActionLiteralSelector
            : ISelector<Action>
    {
        public readonly Action Action;

        public ActionLiteralSelector(Action action)
        {
            Action = action;
        }

        public Action Evaluate(GameContext context)
        {
            return this.Action;
        }
    }
}
