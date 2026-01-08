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

                ActionHelpers.Move(targetCard, chosenSocket);

                //TODO!CRITICAL this currently doesn't work with interrupts; it also needs to take in a parameter that would allow interrupts to be installed locked or unlocked
                this is just to break compilation
            }
        }
    }
}
