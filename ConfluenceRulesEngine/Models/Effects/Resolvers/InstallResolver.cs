using ConfluenceRulesEngine.Helpers;
using ConfluenceRulesEngine.Models.Effects.Actions;
using ConfluenceRulesEngine.Models.Effects.Evaluators;
using ConfluenceRulesEngine.Models.Effects.Selectors;
using ConfluenceRulesEngine.Models.Shared;

namespace ConfluenceRulesEngine.Models.Effects.Resolvers
{
    public class InstallResolver
        : IActionResolver<InstallAction>
    {
        public void Resolve(InstallAction action, ResolutionContext resolutionContext, GameContext gameContext)
        {
            var chosenSlotEvaluator = new ChooseSingleEvaluator(action.TargetPlayer, new SocketsEvaluator(action.AllowedSlots));

            if (chosenSlotEvaluator.Evaluate(gameContext) is int chosenSocketId)
            {
                // TODO handle trashing of already-installed cards here

                var targetCardId = action.ChosenCard.Evaluate(gameContext)
                    ?? throw new InvalidOperationException("Chosen card evaluator for install action returned null!");

                var targetCard = gameContext.CardObjects[targetCardId];

                ActionHelpers.Move(targetCard, targetCard.CurrentZone, gameContext.Sockets[chosenSocketId]);
            }
        }
    }
}
