namespace ConfluenceRulesEngine.Test.Helpers
{
    using ConfluenceRulesEngine.Helpers;
    using ConfluenceRulesEngine.Models.Shared;
    using ConfluenceRulesEngine.Models.Zones;
    using System.Threading.Tasks;
    using static ConfluenceRulesEngine.Models.Shared.Enums;

    public class SelectorHeplersTests
    {
        [TestClass]
        public class GetNonInterruptSocketsForPlayer
        {
            [TestMethod]
            [DataRow(PlayerId.A)]
            [DataRow(PlayerId.B)]
            public void GetsAllSocketsForPlayer(PlayerId playerId)
            {
                // Arrange
                List<IZone> board = [];

                for (int i = 0; i < 24; i++)
                {
                    board.Add(new Socket());
                }

                var context = new GameContext(board, [], [], []);

                // Act
                var result = SelectorHelpers.GetSocketsForPlayer(playerId, SocketType.Any, context);

                // Assert
                var expectedSockets = board.Skip((int)playerId);

                Assert.IsTrue(result.All(resultSocket => expectedSockets.Contains(resultSocket)));
            }

            [TestMethod]
            [DataRow(PlayerId.A)]
            [DataRow(PlayerId.B)]
            public void GetsProperNonInterruptSocketsForPlayer(PlayerId playerId)
            {
                // Arrange
                List<IZone> board = [];

                for (int i = 0; i < 24; i++)
                {
                    board.Add(new Socket());
                }

                var context = new GameContext(board, [], [], []);

                // Act
                var result = SelectorHelpers.GetSocketsForPlayer(playerId, SocketType.NonInterrupt, context);

                // Assert
                List<IZone> expectedSockets = playerId == PlayerId.A
                    ? [board[0], board[2], board[4], board[6], board[8], board[10],]
                    : [board[12], board[14], board[16], board[18], board[20], board[22],];

                Assert.IsTrue(result.All(resultSocket => expectedSockets.Contains(resultSocket)));
            }

            [TestMethod]
            [DataRow(PlayerId.A)]
            [DataRow(PlayerId.B)]
            public void GetsProperInterruptSocketsForPlayer(PlayerId playerId)
            {
                // Arrange
                List<IZone> board = [];

                for (int i = 0; i < 24; i++)
                {
                    board.Add(new Socket(i));
                }

                var context = new GameContext(board, [], [], []);

                // Act
                var result = SelectorHelpers.GetSocketsForPlayer(playerId, SocketType.Interrupt, context);

                // Assert
                List<IZone> expectedSockets = playerId == PlayerId.A
                    ? [board[1], board[3], board[5], board[7], board[9], board[11],]
                    : [board[13], board[15], board[17], board[19], board[21], board[23],];

                Assert.IsTrue(result.All(resultSocket => expectedSockets.Contains(resultSocket)));
            }
        }
    }
}
