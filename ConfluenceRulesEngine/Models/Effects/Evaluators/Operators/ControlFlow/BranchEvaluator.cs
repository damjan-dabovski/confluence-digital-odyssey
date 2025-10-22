using ConfluenceRulesEngine.Models.Effects.Selectors;
using ConfluenceRulesEngine.Models.Shared;

namespace ConfluenceRulesEngine.Models.Effects.Evaluators.Operators.ControlFlow
{
    public class BranchEvaluator<T>
        : IEvaluator<T>
    {
        public readonly IEvaluator<bool> Condition;
        public readonly IEvaluator<T> TrueCase;
        public readonly IEvaluator<T> FalseCase;

        public BranchEvaluator(IEvaluator<bool> condition, IEvaluator<T> trueCase, IEvaluator<T> falseCase)
        {
            this.Condition = condition;
            this.TrueCase = trueCase;
            this.FalseCase = falseCase;
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
