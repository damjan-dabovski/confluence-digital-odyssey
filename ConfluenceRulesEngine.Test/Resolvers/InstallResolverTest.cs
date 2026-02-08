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
        private readonly GameContext context;
        private readonly Player player;
        private readonly Mock<ICommService> commService = new();
        private readonly InstallResolver resolver = new();

        public InstallResolverTest()
        {
            var sockets = new List<Socket>();

            for (var i = 0; i < 24; i++)
            {
                sockets.Add(new(i));
            }

            context = new GameContext(
                sockets,
                [],
                []);

            player = new Player("A", new Deck([]), commService.Object);

            commService.Setup(x => x.GetInput())
                .Returns(0);
        }

        [TestMethod]
        public void InstallsCardInSocket()
        {
            // Arrange
            var card = new Card(1, 1, "TestCard", CardType.Function, [], player, player.Hand);

            player.Hand.Cards.Add(card);

            var cardObjects = new Dictionary<int, Card>
            {
                { 1, card }
            };

            var playerEvaluator = new LiteralEvaluator<Player>(player);

            var cardsFromHandEvaluator = new NonInstalledCardsEvaluator(new OwnedZoneEvaluator(playerEvaluator, ZoneType.Hand));

            var chosenCardEvaluator = new ChooseSingleEvaluator<Card>(playerEvaluator, cardsFromHandEvaluator);

            var coordsFilterEvaluator = new LiteralEvaluator<CoordsFilter>(new CoordsFilter(Row.P1, Col.S1, false, PlayerId.A));

            var action = new InstallAction(
                chosenCardEvaluator,
                playerEvaluator,
                coordsFilterEvaluator);

            // Act
            resolver.Resolve(action, new ResolutionContext(PlayerId.A, Row.P1, Col.S1), context);

            // Assert
            Assert.IsTrue(context.Sockets[0].Cards.All(c => c.ObjectId == card.ObjectId));
        }

        [TestMethod]
        [DataRow(true)]
        [DataRow(false)]
        public void InstallsInterruptInSocket(bool installInterruptLocked)
        {
            // Arrange
            var card = new Card(1, 1, "TestCard", CardType.Function, [], player, player.Hand);

            player.Hand.Cards.Add(card);

            var cardObjects = new Dictionary<int, Card>
            {
                { 1, card }
            };

            var playerEvaluator = new LiteralEvaluator<Player>(player);

            var cardsFromHandEvaluator = new NonInstalledCardsEvaluator(new OwnedZoneEvaluator(playerEvaluator, ZoneType.Hand));

            var chosenCardEvaluator = new ChooseSingleEvaluator<Card>(playerEvaluator, cardsFromHandEvaluator);

            var coordsFilterEvaluator = new LiteralEvaluator<CoordsFilter>(new CoordsFilter(Row.P1, Col.S1, true, PlayerId.A));

            var interruptLockedEvaluator = new LiteralEvaluator<bool>(installInterruptLocked);

            var action = new InstallAction(
                chosenCardEvaluator,
                playerEvaluator,
                coordsFilterEvaluator,
                interruptLockedEvaluator);

            // Act
            resolver.Resolve(action, new ResolutionContext(PlayerId.A, Row.P1, Col.S1), context);

            // Assert
            Assert.IsTrue(context.Sockets[1].Cards.All(c => c.ObjectId == card.ObjectId));
            Assert.AreEqual(installInterruptLocked, context.Sockets[1].InterruptLocked);
        }

        [TestMethod]
        public void DefaultsToInstallingInterruptsLocked()
        {
            // Arrange
            var card = new Card(1, 1, "TestCard", CardType.Function, [], player, player.Hand);

            player.Hand.Cards.Add(card);

            var cardObjects = new Dictionary<int, Card>
            {
                { 1, card }
            };

            var playerEvaluator = new LiteralEvaluator<Player>(player);

            var cardsFromHandEvaluator = new NonInstalledCardsEvaluator(new OwnedZoneEvaluator(playerEvaluator, ZoneType.Hand));

            var chosenCardEvaluator = new ChooseSingleEvaluator<Card>(playerEvaluator, cardsFromHandEvaluator);

            var coordsFilterEvaluator = new LiteralEvaluator<CoordsFilter>(new CoordsFilter(Row.P1, Col.S1, true, PlayerId.A));

            var action = new InstallAction(
                chosenCardEvaluator,
                playerEvaluator,
                coordsFilterEvaluator);

            // Act
            resolver.Resolve(action, new ResolutionContext(PlayerId.A, Row.P1, Col.S1), context);

            // Assert
            Assert.IsTrue(context.Sockets[1].Cards.All(c => c.ObjectId == card.ObjectId));
            Assert.IsTrue(context.Sockets[1].InterruptLocked);
        }

        [TestMethod]
        public void ThrowsIfTryingToInstallNonFunctionInInterruptSocket()
        {
            // Arrange
            var card = new Card(1, 1, "TestCard", CardType.Lambda, [], player, player.Hand);

            player.Hand.Cards.Add(card);

            var cardObjects = new Dictionary<int, Card>
            {
                { 1, card }
            };

            var playerEvaluator = new LiteralEvaluator<Player>(player);

            var cardsFromHandEvaluator = new NonInstalledCardsEvaluator(new OwnedZoneEvaluator(playerEvaluator, ZoneType.Hand));

            var chosenCardEvaluator = new ChooseSingleEvaluator<Card>(playerEvaluator, cardsFromHandEvaluator);

            var coordsFilterEvaluator = new LiteralEvaluator<CoordsFilter>(new CoordsFilter(Row.P1, Col.S1, true, PlayerId.A));

            var action = new InstallAction(
                chosenCardEvaluator,
                playerEvaluator,
                coordsFilterEvaluator);

            // Act
            var act = () => resolver.Resolve(action, new ResolutionContext(PlayerId.A, Row.P1, Col.S1), context);

            // Assert
            Assert.ThrowsExactly<InvalidOperationException>(act);
        }
    }
}
