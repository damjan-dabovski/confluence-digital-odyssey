namespace ConfulenceRulesEngine.Experiments.Selectors
{
    using ConsoleApp1;

    public class BooleanLiteralSelector
            : ISelector<bool>
    {
        public readonly bool Value;

        public BooleanLiteralSelector(bool value)
        {
            Value = value;
        }

        public bool Evaluate(GameContext context)
        {
            return this.Value;
        }
    }
}
