using ConfluenceRulesEngine.Models.Core;

namespace ConfluenceRulesEngine.Services
{
    public class GameService
            : IGameService
    {
        public string GetNextState(Game game)
        {
            return game.Serialize();
        }
    }
}
