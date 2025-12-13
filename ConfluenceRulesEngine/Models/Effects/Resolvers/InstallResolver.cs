using ConfluenceRulesEngine.Helpers;
using ConfluenceRulesEngine.Models.Core;
using ConfluenceRulesEngine.Models.Effects.Actions;
using ConfluenceRulesEngine.Models.Effects.Evaluators;
using ConfluenceRulesEngine.Models.Effects.Evaluators.Helpers;
using ConfluenceRulesEngine.Models.Shared;
using ConfluenceRulesEngine.Models.Zones;

namespace ConfluenceRulesEngine.Models.Effects.Resolvers
{
    public class InstallResolver
        : IActionResolver<InstallAction>
    {
        public void Resolve(InstallAction installAction, ResolutionContext resolutionContext, GameContext gameContext)
        {
            var chosenSocketEvaluator = new ChooseSingleEvaluator<Socket>(
                installAction.TargetPlayer,
                new SocketsEvaluator(installAction.AllowedSlots));

            if (chosenSocketEvaluator.Evaluate(gameContext) is Socket chosenSocket)
            {
                if (chosenSocket.Cards.Count != 0)
                {
                    var existingCard = chosenSocket.Cards.First();

                    var existingCardTrashAction = new TrashAction(
                        new LiteralEvaluator<IEnumerable<Card>>([existingCard]),
                        installAction);

                    // TODO!IMPORTANT use an actual deque for this, even an in-house implementation would suffice
                    // since there's currently no consistent semantics for what the beginning and end of the queue are
                    gameContext.ActionQueue.Add(existingCardTrashAction);
                    return;
                }

                var targetCard = installAction.ChosenCard.Evaluate(gameContext);

                if (targetCard is null)
                {
                    return;
                }

                ActionHelpers.Move(targetCard, chosenSocket);
            }
        }
    }
}
