using ConfluenceRulesEngine.Models.Creation;
using ConfluenceRulesEngine.Models.Effects;
using ConfluenceRulesEngine.Models.Zones;

using System.Text.Json;
using System.Text.Json.Serialization;

using static ConfluenceRulesEngine.Models.Shared.Enums;

namespace ConfluenceRulesEngine.Models.Core
{
    public class Game
    {
        [JsonInclude]
        public readonly Guid Id;

        [JsonInclude]
        public readonly Player[] Players;

        private readonly Dictionary<int, IEnumerable<CardEffect>> CardEffects;

        private readonly Socket[] board = new Socket[24];

        public Game(Guid Id, Dictionary<int, CardInitModel> CardPool, PlayerInitModel activePlayer, PlayerInitModel inactivePlayer)
        {
            this.Id = Id;

            CardEffects = CardPool.ToDictionary(x => x.Key, x => x.Value.CardEffects);

            Players =
            [
                new(activePlayer.Name, MapDeckFromCardIds(PlayerId.A, activePlayer.CardIds, CardPool), activePlayer.CommService),
                new(inactivePlayer.Name, MapDeckFromCardIds(PlayerId.B, activePlayer.CardIds, CardPool), inactivePlayer.CommService)
            ];

            CardEffects = [];
        }

        public string Serialize() => JsonSerializer.Serialize(this);

        private static Deck MapDeckFromCardIds(PlayerId ownerId, IEnumerable<int> cardIds, Dictionary<int, CardInitModel> CardPool)
        {
            var mappedCards = cardIds.Select((id, index) => new Card(
                id,
                index,
                CardPool[id].Name,
                CardPool[id].Type,
                CardPool[id].CardEffects,
                ownerId,
                null!)); // TODO since we want a Deck to be constructed with the Cards,
                         // but the Cards need to be constructed with a Zone, one has to take precedence
                         // so this is an explicit null because it otherwise makes no sense for Card.CurrentZone to be null

            return new(mappedCards);
        }
    };
}
