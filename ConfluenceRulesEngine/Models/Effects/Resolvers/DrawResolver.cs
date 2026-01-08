using ConfluenceRulesEngine.Helpers;
using ConfluenceRulesEngine.Models.Effects.Actions;
using ConfluenceRulesEngine.Models.Shared;

namespace ConfluenceRulesEngine.Models.Effects.Resolvers
{
    public class DrawResolver
        : IActionResolver<DrawAction>
    {
        public void Resolve(DrawAction action, ResolutionContext resolutionContext, GameContext gameContext)
        {
            foreach (var card in action.Targets.Evaluate(gameContext))
            {
                ActionHelpers.Move(card, card.Owner.Hand);
            }
        }
    }
}
