namespace ConfulenceRulesEngine.Experiments.Selectors
{
    using ConfulenceRulesEngine.Experiments.Actions;
    using ConsoleApp1;

    public class RepeatSelector
            : ISelector<Action>
    {
        public readonly int Amount;

        public readonly ISelector<Action> Action;

        public RepeatSelector(int amount, ISelector<Action> action)
        {
            Amount = amount;
            Action = action;
        }

        public Action Evaluate(GameContext context)
        {
            if (this.Amount > 0)
            {
                context.ActionQueue.Add(new RepeatSelector(this.Amount - 1, this.Action));
            }

            return this.Action.Evaluate(context);
        }
    }
}
