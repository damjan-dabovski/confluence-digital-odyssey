namespace ConfluenceRulesEngine.Test.Services
{
    using ConfluenceRulesEngine.Models;
    using ConfluenceRulesEngine.Services;
    using System.Threading.Tasks;

    public class GameServiceTest
    {
        private readonly GameService service;

        public GameServiceTest()
        {
            this.service = new();
        }

        [TestClass]
        public class GetNextState
        : GameServiceTest
        {
            [TestMethod]
            public void GetsNextStateAsJson()
            {
                // Arrange
                var game = new Game(
                    Guid.NewGuid(),
                    new("Active", []),
                    new("Inactive", []));

                // Act
                var newState = service.GetNextState(game);

                // Assert
                Assert.IsFalse(string.IsNullOrEmpty(newState));
            }
        }
    }
}
