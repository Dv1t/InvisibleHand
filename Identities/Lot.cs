using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace InvisibleHand.Identities
{
    public class Lot
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("Product")]
        public string Product { get; set; }

        [BsonElement("Price")]
        public double Price { get; set; }

        [BsonElement("Sell")]
        public bool Sell { get; set; }

        [BsonElement("Owner")]
        public string Owner { get; set; }

    }
}
