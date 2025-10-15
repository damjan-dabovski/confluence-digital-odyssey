namespace ConfluenceRulesEngine.Models.Effects.Actions
{
    public class DrawAction
        : Action
    {
        public readonly IEnumerable<int> Targets;

        public DrawAction(IEnumerable<int> targets, Action? continuation = null)
            : base(continuation)
        {
            this.Targets = targets;
        }
    }
}
