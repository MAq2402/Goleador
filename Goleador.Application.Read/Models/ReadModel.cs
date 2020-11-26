using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Goleador.Application.Read.Models
{
    public abstract class ReadModel
    {
        [BsonId]
        public Guid Id { get; set; }
    }
}
