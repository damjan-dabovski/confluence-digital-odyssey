namespace ConfluenceRulesEngine.Test
{
    using ConfluenceRulesEngine.Models;

    [TestClass]
    public sealed class GameTest
    {
        [TestMethod]
        public void SerializesGameState()
        {
            // Arrange
            var game = new Game(Guid.NewGuid());

            // Act
            var json = game.Serialize();

            // Assert
            Assert.IsFalse(string.IsNullOrEmpty(json));
        }
    }
}
