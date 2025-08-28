namespace ConfluenceRulesEngine.Services
{
    using ConfluenceRulesEngine.Models.Core;

    public class GameService
            : IGameService
    {
        public string GetNextState(Game game)
        {
            return game.Serialize();
        }
    }
}
