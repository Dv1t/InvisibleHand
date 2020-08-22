using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;

namespace InvisibleHand.Identities
{
    public class User
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("Number")]
        public string Number { get; set; }


        [BsonElement("Name")]
        public string Name { get; set; }

        [BsonElement("Balance")]
        public float Balance { get; set; }
    }
}
