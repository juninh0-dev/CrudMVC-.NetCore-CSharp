using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace treinandoParaProva.Models
{
    public class Avaliacao
    {
        [BsonElement("Nota"), BsonRepresentation(BsonType.Int32)]
        public int Nota { get; set; }

        [BsonElement("Comentario"), BsonRepresentation(BsonType.String)]
        public string? Comentario { get; set; }

        [BsonElement("DataAvaliacao"), BsonRepresentation(BsonType.DateTime)]
        public DateTime DataAvaliacao { get; set; }
    }
}