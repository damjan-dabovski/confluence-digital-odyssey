namespace ConsoleApp1
{
    using ConfulenceRulesEngine.Experiments;
    using static ConsoleApp1.Enums;

    public class Program
    {
        static ChoiceResolver choiceResolver = new();
        static TrashResolver trashResolver = new();

        static void Main(string[] _)
        {
            var cards = new Dictionary<int, Card> {
                { 1, new(1, PlayerId.A) },
                { 2, new(2, PlayerId.B) },
            };

            var context = new GameContext(cards);

            context.Store["owner"] = PlayerId.B;

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

            var choiceAction = new ChoiceAction(
                new ContextSelector<PlayerId>("owner"),
                new CardSelector()
                {
                    Zone = new(new ContextSelector<PlayerId>("owner"), Enums.ZoneType.Board),
                    Type = Enums.CardType.Function
                },
                new TrashAction(new ContextSelector<IEnumerable<int>>("choice"))
            );

            context.ActionQueue.Add(choiceAction);

            //while (context.ActionQueue.Count != 0)
            //{
            //    var next = context.ActionQueue[^1];
            //    context.ActionQueue.Remove(next);
            //    Resolve(next, context);
            //}

            Helpers.GetPositionFromCoords(new(Row.P3, Col.S1, true, PlayerId.A));
            var test= Helpers.GetCoordsFromPosition(3);
        }

        static void Resolve(Action action, GameContext context)
        {
            switch(action)
            {
                case ChoiceAction ca:
                    choiceResolver.Resolve(ca, context);
                    break;
                case TrashAction ta:
                    trashResolver.Resolve(ta, context);
                    break;
                default:
                    throw new InvalidOperationException("No resolver for that action type");
            };
        }
    }
}
