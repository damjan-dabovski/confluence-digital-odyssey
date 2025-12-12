using ConfluenceRulesEngine.Models.Core;
using ConfluenceRulesEngine.Services;
using Moq;

namespace ConfluenceRulesEngine.Test.Models
{
    [TestClass]
    public sealed class GameTest
    {
        [TestMethod]
        public void SerializesGameState()
        {
            // Arrange
            var mockCommService = new Mock<ICommService>();

            var game = new Game(
                Guid.NewGuid(),
                [],
                new("Active", [], mockCommService.Object),
                new("Inactive", [], mockCommService.Object));

            // Act
            var json = game.Serialize();

            // Assert
            Assert.IsFalse(string.IsNullOrEmpty(json));
        }
    }
}
