using ConfluenceRulesEngine.Models.Effects.Evaluators;
using ConfluenceRulesEngine.Models.Shared;

namespace ConfluenceRulesEngine.Models.Effects.Actions
{
    public abstract class Action
        : IEvaluator<Action>
    {
        public readonly Action? Continuation;

        public Action(Action? continuation = null)
        {
            this.Continuation = continuation;
        }

        public Action Evaluate(GameContext context) => this;
    }
}
