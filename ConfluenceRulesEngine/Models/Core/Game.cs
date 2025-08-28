namespace ConfluenceRulesEngine.Models.Core
{
    using ConfluenceRulesEngine.Models.Creation;
    using ConfluenceRulesEngine.Models.Effects;
    using ConfluenceRulesEngine.Models.Zones;
    using System.Text.Json;
    using System.Text.Json.Serialization;

    public class Game
    {
        [JsonInclude]
        public readonly Guid Id;

        [JsonInclude]
        public readonly Player[] Players;

        private readonly Dictionary<int, IEnumerable<GameAction>> CardEffects;

        public Game(Guid Id, Dictionary<int, CardInitModel> CardPool, PlayerInitModel ActivePlayer, PlayerInitModel InactivePlayer)
        {
            this.Id = Id;

            CardEffects = CardPool.ToDictionary(x => x.Key, x => x.Value.EffectActions);

            Players =
            [
                new(ActivePlayer.Name, MapDeckFromCardIds(ActivePlayer.CardIds, CardPool)),
                new(InactivePlayer.Name, MapDeckFromCardIds(ActivePlayer.CardIds, CardPool))
            ];
        }

        public string Serialize()
        {
            return JsonSerializer.Serialize(this);
        }

        private static Deck MapDeckFromCardIds(IEnumerable<int> cardIds, Dictionary<int, CardInitModel> CardPool)
        {
            var mappedCards = cardIds.Select(id => new Card(
                id,
                0,
                CardPool[id].Name,
                CardPool[id].EffectActions));

            return new(mappedCards);
        }
    };
}
