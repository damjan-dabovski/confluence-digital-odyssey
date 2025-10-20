namespace ConfluenceRulesEngine.Test.TestHelpers.Fakes
{
    using ConfluenceRulesEngine.Models.Effects.Selectors;
    using ConfluenceRulesEngine.Models.Shared;

    public class FakeSelector<T>
        : ISelector<T>
    {
        public readonly T Value;

        public FakeSelector(T value)
        {
            Value = value;
        }

        public T Evaluate(GameContext context)
        {
            return this.Value;
        }
    }
}
