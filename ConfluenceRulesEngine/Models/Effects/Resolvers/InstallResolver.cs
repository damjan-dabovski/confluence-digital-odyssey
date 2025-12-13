using ConfluenceRulesEngine.Helpers;
using ConfluenceRulesEngine.Models.Effects.Actions;
using ConfluenceRulesEngine.Models.Effects.Evaluators;
using ConfluenceRulesEngine.Models.Shared;
using ConfluenceRulesEngine.Models.Zones;

namespace ConfluenceRulesEngine.Models.Effects.Resolvers
{
    public class InstallResolver
        : IActionResolver<InstallAction>
    {
        public void Resolve(InstallAction action, ResolutionContext resolutionContext, GameContext gameContext)
        {
            var chosenSocketEvaluator = new ChooseSingleEvaluator<Socket>(
                action.TargetPlayer,
                new SocketsEvaluator(action.AllowedSlots));

            if (chosenSocketEvaluator.Evaluate(gameContext) is Socket chosenSocket)
            {
                // TODO handle trashing of already-installed cards here

                var targetCard = action.ChosenCard.Evaluate(gameContext);

                if (targetCard is null)
                {
                    return;
                }

                ActionHelpers.Move(
                    targetCard,
                    targetCard.CurrentZone,
                    chosenSocket);
            }
        }
    }
}
