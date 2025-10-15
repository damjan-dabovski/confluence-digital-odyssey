using static ConsoleApp1.Enums;

namespace ConfulenceRulesEngine.Experiments.Actions
{
    public class Card
    {
        public int ObjectId;
        public PlayerId OwnerId;

        public Card(int objectId, PlayerId ownerId)
        {
            ObjectId = objectId;
            OwnerId = ownerId;
        }
    }
}
