using ConfluenceRulesEngine.Models.Effects.Selectors;

namespace ConfluenceRulesEngine.Models.Effects.Actions
{
    public class TrashAction
        : Action
    {
        public readonly IEvaluator<IEnumerable<int>> Targets;

        public TrashAction(IEvaluator<IEnumerable<int>> targets, Action? continuation = null)
            : base(continuation)
        {
            this.Targets = targets;
        }

    }
}
