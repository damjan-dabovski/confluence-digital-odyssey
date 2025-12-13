using ConfluenceRulesEngine.Helpers;
using ConfluenceRulesEngine.Models.Effects.Actions;
using ConfluenceRulesEngine.Models.Shared;

namespace ConfluenceRulesEngine.Models.Effects.Resolvers
{
    public class TrashResolver
        : IActionResolver<TrashAction>
    {
        public void Resolve(TrashAction action, ResolutionContext resolutionContext, GameContext gameContext)
        {
            foreach (var targetCard in action.Targets.Evaluate(gameContext))
            {
                // TODO handle prompting users for ordering the cards when multiple are
                // trashed at once (incl. splitting the card processing in APNAP order)

                ActionHelpers.Move(
                    targetCard,
                    targetCard.CurrentZone,
                    targetCard.Owner.Trash);
            }
        }
    }
}
