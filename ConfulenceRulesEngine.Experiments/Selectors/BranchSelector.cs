namespace ConfulenceRulesEngine.Experiments.Selectors
{
    using ConsoleApp1;

    public class BranchSelector<T>
        : ISelector<T>
    {
        public readonly ISelector<bool> Condition;

        public readonly ISelector<T> TrueCase;

        public readonly ISelector<T> FalseCase;

        public BranchSelector(ISelector<bool> condition, ISelector<T> trueCase, ISelector<T> falseCase)
        {
            Condition = condition;
            TrueCase = trueCase;
            FalseCase = falseCase;
        }

        public T Evaluate(GameContext context)
        {
            var conditionValue = this.Condition.Evaluate(context);

            return conditionValue
                ? this.TrueCase.Evaluate(context)
                : this.FalseCase.Evaluate(context);
        }
    }
}
