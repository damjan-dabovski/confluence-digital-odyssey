using System.Collections;

using ConfluenceRulesEngine.Models.Core;

namespace ConfluenceRulesEngine.Models.Shared
{
    /// <summary>
    /// Horrible hack to have a single-item 'Collection'.
    /// TODO figure out a better way to do this.
    /// </summary>
    public class SingleCardCollection
        : ICollection<Card>
    {
        public Card? Value { get; private set; }

        public SingleCardCollection()
        {
            this.Value = null;
        }

        public SingleCardCollection(Card value)
        {
            this.Value = value;
        }

        public void Add(Card item)
        {
            if (this.Value is not null)
            {
                this.Value = item;
            }
            else
            {
                throw new InvalidOperationException("There is already an item in that socket.");
            }
        }

        public void Clear() => this.Value = null;

        public bool Contains(Card item) => this.Value == item;

        public void CopyTo(Card[] array, int arrayIndex) => throw new NotImplementedException();

        public bool Remove(Card item)
        {
            if (this.Value is not null)
            {
                this.Value = null;
                return true;
            }
            else
            {
                return false;
            }
        }

        public int Count => this.Value is null ? 0 : 1;

        public bool IsReadOnly => false;

        public IEnumerator<Card> GetEnumerator()
        {
            if (this.Value is not null)
            {
                yield return this.Value;
            }
            else
            {
                yield break;
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();
    }
}
