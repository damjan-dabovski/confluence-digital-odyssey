namespace ConsoleApp1
{
    using ConfulenceRulesEngine.Experiments.Actions;
    using ConfulenceRulesEngine.Experiments.Selectors;
    using System.Collections.Generic;
    using Action = ConfulenceRulesEngine.Experiments.Actions.Action;

    public class GameContext
    {
        public Dictionary<int, Card> Cards;
        public Dictionary<string, object> Store;
        public List<ISelector<Action>> ActionQueue;

        public GameContext(Dictionary<int, Card> cards)
        {
            this.Cards = cards;
            this.Store = new();
            this.ActionQueue = new();
        }
    }
}
