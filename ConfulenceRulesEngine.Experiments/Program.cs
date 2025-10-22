namespace ConsoleApp1
{
    using ConfulenceRulesEngine.Experiments;
    using ConfulenceRulesEngine.Experiments.Actions;
    using ConfulenceRulesEngine.Experiments.Resolvers;
    using ConfulenceRulesEngine.Experiments.Selectors;
    using static ConsoleApp1.Enums;

    public class Program
    {
        static ChoiceResolver choiceResolver = new();
        static TrashResolver trashResolver = new();
        static DrawResolver drawResolver = new();

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
            var trashAction = new TrashAction(new CardSelector() { Zone = new(new ContextSelector<PlayerId>("owner"), Enums.ZoneType.Board) });

            var drawAction = new DrawAction(2);

            //var choiceAction = new ActionLiteralSelector(new ChoiceAction(
            //    new ContextSelector<PlayerId>("owner"),
            //    new CardSelector()
            //    {
            //        Zone = new(new ContextSelector<PlayerId>("owner"), Enums.ZoneType.Board),
            //        Type = Enums.CardType.Function
            //    },
            //    trashAction
            //));

            //Console.WriteLine("Input 'draw' or 'trash' for what action you want to do");
            //var shouldTrash = Console.ReadLine() switch
            //{
            //    "trash" => true,
            //    "draw" => false,
            //    _ => throw new ArgumentException("You didn't write 'draw' or 'trash'. WTF dude?")
            //};

            //var firstCondition = bool.Parse(Console.ReadLine());
            //var secondCondition = bool.Parse(Console.ReadLine());

            //var branchAction = new BranchSelector<Action>(
            //    new BooleanLiteralSelector(firstCondition),
            //    new BranchSelector<Action>(
            //        new BooleanLiteralSelector(firstCondition && secondCondition),
            //        new ActionLiteralSelector(trashAction),
            //        new ActionLiteralSelector(drawAction)),
            //    new ActionLiteralSelector(drawAction));

            //context.ActionQueue.Add(branchAction);

            var repeatedDrawAction = new RepeatSelector(
                1,
                new BranchSelector<Action>(
                    new BooleanUserInputSelector(),
                    new ActionLiteralSelector(drawAction),
                    new ActionLiteralSelector(trashAction)));

            context.ActionQueue.Add(repeatedDrawAction);

            while (context.ActionQueue.Count != 0)
            {
                var next = context.ActionQueue[^1];
                context.ActionQueue.Remove(next);
                ResolveAction(next, context);
            }
        }

        static void ResolveAction(ISelector<Action> action, GameContext context)
        {
            var actionValue = action.Evaluate(context);

            switch (actionValue)
            {
                case ChoiceAction ca:
                    choiceResolver.Resolve(ca, context);
                    break;
                case TrashAction ta:
                    trashResolver.Resolve(ta, context);
                    break;
                case DrawAction da:
                    drawResolver.Resolve(da, context);
                    break;
                default:
                    throw new InvalidOperationException("No resolver for that action type");
            }
        }
    }
}
