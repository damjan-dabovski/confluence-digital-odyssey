namespace ConsoleApp1
{
    public class GameContext
    {
        public Dictionary<int, Card> Cards;
        public Dictionary<string, object> Store;
        public List<Action> ActionQueue;

        public GameContext(Dictionary<int, Card> cards)
        {
            this.Cards = cards;
            this.Store = new();
            this.ActionQueue = new();
        }
    }
}
