
using ConfluenceRulesEngine.Models.Core;
using ConfluenceRulesEngine.Models.Shared;

namespace ConfluenceRulesEngine.Models.Zones
{
    public class Socket(int objectId)
        : IZone, IChoosable
    {
        private readonly SingleCardCollection card = [];

        public int ObjectId => objectId;

        public ZoneType Type => ZoneType.Socket;

        public ICollection<Card> Cards => card;

        public bool IsInterrupt => objectId % 2 != 0;

        public bool? InterruptLocked = null;

        public void Add(Card card) => this.card.Add(card);

        public void Remove(Card card)
        {
            if (this.card.Value is Card c)
            {
                _ = this.card.Remove(c);
            }

            if (this.IsInterrupt)
            {
                this.InterruptLocked = null;
            }
        }

        public string ToChoiceDisplayString() => $"[{this.ObjectId}: {(this.IsInterrupt ? "Interrupt" : "Non-Interrupt")}]";
    }
}
