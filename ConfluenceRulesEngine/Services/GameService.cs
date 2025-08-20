namespace ConfluenceRulesEngine.Services
{
    using ConfluenceRulesEngine.Models;

    public class GameService
            : IGameService
    {
        public string GetNextState(Game game)
        {
            return game.Serialize();
        }
    }
}
