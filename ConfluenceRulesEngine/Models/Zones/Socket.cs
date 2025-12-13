
using ConfluenceRulesEngine.Models.Core;
using ConfluenceRulesEngine.Models.Effects.Evaluators.Helpers;
using ConfluenceRulesEngine.Models.Shared;

namespace ConfluenceRulesEngine.Models.Zones
{
    public class Socket
        : IZone, IChoosable
    {
        private readonly SingleCardCollection card = [];

        private readonly SocketId objectId;

        public Socket(int objectId)
        {
            this.objectId = new(objectId);
        }

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

        public string ToChoiceDisplayString() => $"[{this.objectId}: {(this.IsInterrupt ? "Interrupt" : "Non-Interrupt")}]";
    }
}
