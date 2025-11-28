using ConfluenceRulesEngine.Models.Effects.Selectors;
using ConfluenceRulesEngine.Models.Shared;

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
                context.ActionQueue.Add(new RepeatActionEvaluator(this.Times - 1, this.Action));
            }

            return this.Action.Evaluate(context);
        }
    }
}
