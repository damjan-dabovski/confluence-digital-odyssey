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

                    gameContext.ActionQueue.AddToFront(existingCardTrashAction);
                    return;
                }

                var targetCard = installAction.ChosenCard.Evaluate(gameContext);

                if (targetCard is null)
                {
                    return;
                }

                // this would be better if it checked against components instead of literal types
                // best save that for the rewrite
                if (chosenSocket.IsInterrupt && targetCard.Type != Enums.CardType.Function)
                {
                    throw new InvalidOperationException("Trying to install a non-FN card in an interrupt slot");
                }

                var installInterruptLocked = installAction.InstallInterruptLocked?.Evaluate(gameContext) ?? true;

                ActionHelpers.Move(targetCard, chosenSocket);

                if (chosenSocket.IsInterrupt)
                {
                    chosenSocket.InterruptLocked = installInterruptLocked;
                }
            }
        }
    }
}
