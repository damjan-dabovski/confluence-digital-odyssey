using ConfluenceRulesEngine.Models.Core;
using ConfluenceRulesEngine.Models.Effects.Evaluators;

namespace ConfluenceRulesEngine.Models.Effects.Actions
{
    public class TrashAction
        : Action
    {
        public readonly IEvaluator<IEnumerable<Card>> Targets;

        public TrashAction(IEvaluator<IEnumerable<Card>> targets, Action? continuation = null)
            : base(continuation)
        {
            this.Targets = targets;
        }

    }
}
