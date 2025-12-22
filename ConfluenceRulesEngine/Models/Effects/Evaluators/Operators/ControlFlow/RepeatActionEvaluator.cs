using ConfluenceRulesEngine.Models.Shared;

using Action = ConfluenceRulesEngine.Models.Effects.Actions.Action;

namespace ConfluenceRulesEngine.Models.Effects.Evaluators.Operators.ControlFlow
{
    public class RepeatActionEvaluator
            : IEvaluator<Action>
    {
        public readonly int Times;

        public readonly IEvaluator<Action> Action;

        public RepeatActionEvaluator(int amount, IEvaluator<Action> action)
        {
            Times = amount;
            Action = action;
        }

        public Action Evaluate(GameContext context)
        {
            if (this.Times > 0)
            {
                context.ActionQueue.AddToBack(new RepeatActionEvaluator(this.Times - 1, this.Action));
            }

            return this.Action.Evaluate(context);
        }
    }
}
