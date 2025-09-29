namespace ConsoleApp1
{
    public class Program
    {
        static void Main(string[] _)
        {
            //var cards = new Dictionary<int, Card> {
            //    { 1, new() }
            //};

            //var context = new GameContext(cards);

            /*
             * choice {
             *  targetPlayer: #owner,
             *  choices: selectCards {
             *      sourceZone: zone {
             *          owner: #owner,
             *          type: board
             *      },
             *      type: [ function ]
             *  },
             *  continuation: trash {
             *      targets: #choice
             *  }
             * }
             */

            var __ = new ChoiceAction(
                /*
                 * TODO is this fucked because of covariance/contravariance?
                 */

                new ContextSelector("owner"),
                new CardSelector()
                {
                    Zone = new(new ContextSelector("owner"), Enums.ZoneType.Board),
                    Type = Enums.CardType.Function
                },
                new TrashAction(new ContextSelector("choice"))
            );
        }
    }
}
