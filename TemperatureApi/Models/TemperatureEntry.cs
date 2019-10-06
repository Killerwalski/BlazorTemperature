using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemperatureApi.Models
{
    public class TemperatureEntry
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        [BsonElement("Time")]
        public DateTime Timestamp { get; set; }
        [BsonElement("Chan 1 - Deg F")]
        public decimal TemperatureF { get; set; }
    }
}
