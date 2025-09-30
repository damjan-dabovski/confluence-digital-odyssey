using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using static ConsoleApp1.Enums;

namespace ConsoleApp1
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
