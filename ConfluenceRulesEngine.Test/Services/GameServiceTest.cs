using ConfluenceRulesEngine.Models.Core;
using ConfluenceRulesEngine.Services;
using Moq;

namespace ConfluenceRulesEngine.Test.Services
{
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
                var mockCommService = new Mock<ICommService>();

                var game = new Game(
                    Guid.NewGuid(),
                    [],
                    new("Active", [], mockCommService.Object),
                    new("Inactive", [], mockCommService.Object));

                // Act
                var newState = service.GetNextState(game);

                // Assert
                Assert.IsFalse(string.IsNullOrEmpty(newState));
            }
        }
    }
}
