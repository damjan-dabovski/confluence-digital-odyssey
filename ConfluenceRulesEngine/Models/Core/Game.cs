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

        public Game(Guid Id, Dictionary<int, CardInitModel> CardPool, PlayerInitModel ActivePlayer, PlayerInitModel InactivePlayer)
        {
            this.Id = Id;

            CardEffects = CardPool.ToDictionary(x => x.Key, x => x.Value.CardEffects);

            Players =
            [
                new(ActivePlayer.Name, MapDeckFromCardIds(PlayerId.A, ActivePlayer.CardIds, CardPool)),
                new(InactivePlayer.Name, MapDeckFromCardIds(PlayerId.B, ActivePlayer.CardIds, CardPool))
            ];

            CardEffects = [];
        }

        public string Serialize()
        {
            return JsonSerializer.Serialize(this);
        }

        private static Deck MapDeckFromCardIds(PlayerId ownerId, IEnumerable<int> cardIds, Dictionary<int, CardInitModel> CardPool)
        {
            var mappedCards = cardIds.Select((id, index) => new Card(
                id,
                index,
                CardPool[id].Name,
                CardPool[id].CardEffects,
                ownerId,
                null));

            return new(mappedCards);
        }
    };
}
