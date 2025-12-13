namespace ConfluenceRulesEngine.Models.Shared
{
    public interface IChoosable
    {
        public int ObjectId { get; }

        public string ToChoiceDisplayString();
    }
}
