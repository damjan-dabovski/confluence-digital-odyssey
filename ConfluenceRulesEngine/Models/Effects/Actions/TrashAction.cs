namespace ConfluenceRulesEngine.Models.Effects.Actions
{
    public class TrashAction
        : Action
    {
        public TrashAction(IEnumerable<int> targets, Action? continuation = null)
            : base(continuation)
        {
            this.Targets = targets;
        }

        public readonly IEnumerable<int> Targets;
    }
}
