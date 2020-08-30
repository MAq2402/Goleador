using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Bson.Serialization.Attributes;

namespace Goleador.Infrastructure.Types
{
    public abstract class ReadModel 
    {
        [BsonId]
        public Guid Id { get; set; }
    }
}
