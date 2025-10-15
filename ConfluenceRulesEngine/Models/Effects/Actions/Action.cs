namespace ConfluenceRulesEngine.Models.Effects.Actions
{
    public abstract class Action
    {
        public readonly Action? Continuation;

        public Action(Action? continuation = null)
        {
            this.Continuation = continuation;
        }
    }
}
