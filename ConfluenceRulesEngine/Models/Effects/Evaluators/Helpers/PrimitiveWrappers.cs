namespace ConfluenceRulesEngine.Models.Effects.Evaluators.Helpers
{
    public record CardId(int Value)
    {
        public static implicit operator int(CardId cardId) => cardId.Value;
    }

    public record SocketId(int Value)
    {
        public static implicit operator int(SocketId socketId) => socketId.Value;
    }
}
