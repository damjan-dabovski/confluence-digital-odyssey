using ConfluenceRulesEngine.Models.Core;
using ConfluenceRulesEngine.Models.Effects.Actions;
using ConfluenceRulesEngine.Models.Effects.Evaluators;
using ConfluenceRulesEngine.Models.Effects.Evaluators.Helpers;
using ConfluenceRulesEngine.Models.Effects.Resolvers;
using ConfluenceRulesEngine.Models.Shared;
using ConfluenceRulesEngine.Models.Zones;
using ConfluenceRulesEngine.Services;
using Moq;
using static ConfluenceRulesEngine.Models.Shared.Enums;

namespace ConfluenceRulesEngine.Test.Resolvers
{
    [TestClass]
    public class InstallResolverTest
    {
        [TestMethod]
        public void InstallsCardInSocket()
        {
            // Arrange
            var sockets = new List<Socket>();

            for (var i = 0; i < 24; i++)
            {
                sockets.Add(new(i));
            }

            var mockCommService = new Mock<ICommService>();

            mockCommService.Setup(x => x.GetInput())
                .Returns(0);

            var player = new Player("A", new Deck([]), mockCommService.Object);

            var card = new Card(1, 1, "TestCard", CardType.Function, [], player, player.Hand);

            player.Hand.Cards.Add(card);

            var cardObjects = new Dictionary<int, Card>
            {
                { 1, card }
            };

            var context = new GameContext(
                sockets,
                //cardObjects,
                //new() { { PlayerId.A, player } },
                [],
                []);

            var resolver = new InstallResolver();

            var playerIdEvaluator = new LiteralEvaluator<Player>(player);

            var cardsFromHandEvaluator = new NonInstalledCardsEvaluator(new OwnedZoneEvaluator(playerIdEvaluator, ZoneType.Hand));

            var chosenCardEvaluator = new ChooseSingleEvaluator<Card>(playerIdEvaluator, cardsFromHandEvaluator);

            var coordsFilterEvaluator = new LiteralEvaluator<CoordsFilter>(new CoordsFilter(Row.P1, Col.S1, false, PlayerId.A));

            var action = new InstallAction(
                chosenCardEvaluator,
                playerIdEvaluator,
     coordsFilterEvaluator);

            // Act
            resolver.Resolve(action, new ResolutionContext(PlayerId.A, Row.P1, Col.S1), context);

            // Assert
            Assert.IsTrue(context.Sockets[0].Cards.All(c => c.ObjectId == card.ObjectId));
        }
    }
}
