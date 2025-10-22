using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;


namespace KubernetesAssignment.Models;

    public class TodoItem
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [BsonElement("Tasks")]
        [JsonPropertyName("Tasks")]
        
        public string Tasks { get; set; }
        public bool IsCompleted { get; set; }

    }
