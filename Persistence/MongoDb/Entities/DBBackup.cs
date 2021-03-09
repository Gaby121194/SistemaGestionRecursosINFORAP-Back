using INFORAP.API.Persistence.Context;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace INFORAP.API.Persistence.MongoDb.Entities
{
    public class DBBackup : BaseEntity
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Backup { get; set; }
        public string Name { get; set; }


    }
}
