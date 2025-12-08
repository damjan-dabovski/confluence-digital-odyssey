using ConfluenceRulesEngine.Models.Effects.Evaluators;
using ConfluenceRulesEngine.Models.Effects.Evaluators.Helpers;

namespace ConfluenceRulesEngine.Models.Effects.Actions
{
    public class TrashAction
        : Action
    {
        public readonly IEvaluator<IEnumerable<CardId>> Targets;

        public TrashAction(IEvaluator<IEnumerable<CardId>> targets, Action? continuation = null)
            : base(continuation)
        {
            this.Targets = targets;
        }

    }
}
