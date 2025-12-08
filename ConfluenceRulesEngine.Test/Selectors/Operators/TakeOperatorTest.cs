using ConfluenceRulesEngine.Models.Effects.Evaluators.Operators.List;
using ConfluenceRulesEngine.Models.Shared;
using ConfluenceRulesEngine.Test.TestHelpers.Fakes;

namespace ConfluenceRulesEngine.Test.Selectors.Operators
{
    [TestClass]
    public class TakeOperatorTest
    {
        [TestMethod]
        public void TakesOnlyGivenAmount()
        {
            // Arrange
            var context = new GameContext([], [], [], [], []);

            var list = new FakeSelector<IEnumerable<int>>([1, 2, 3, 4, 5]); //TODO use mocks for this instead of fakes?

            var selector = new TakeEvaluator<int>(list, 2);

            // Act
            var result = selector.Evaluate(context);

            // Assert
            Assert.AreEqual(2, result.Count());
        }
    }
}
