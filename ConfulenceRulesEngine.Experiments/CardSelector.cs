using static ConsoleApp1.Enums;

namespace ConsoleApp1
{
    public class CardSelector
        : ISelector<IEnumerable<int>>
    {
        public CardType Type { get; set; }
        public required Zone Zone { get; set; }
        public int Position { get; set; }

        public CardSelector() { }

        public IEnumerable<int> Evaluate(GameContext context)
        {
            // skipping actual implementation here and just returning whatever
            return context.Cards.Select(kvp => kvp.Key);
        }
    }
}
