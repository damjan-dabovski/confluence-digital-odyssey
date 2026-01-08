using ConfluenceRulesEngine.Models.Core;
using ConfluenceRulesEngine.Models.Effects.Evaluators;

namespace ConfluenceRulesEngine.Models.Effects.Actions
{
    public class DrawAction
        : Action
    {
        public readonly IEvaluator<IEnumerable<Card>> Targets;

        public DrawAction(IEvaluator<IEnumerable<Card>> targets, Action? continuation = null)
            : base(continuation)
        {
            this.Targets = targets;
        }
    }
}
