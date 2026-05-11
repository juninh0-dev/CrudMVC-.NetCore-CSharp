using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace treinandoParaProva.Models
{
    public class Autor
    {
        [BsonElement("Nome"), BsonRepresentation(BsonType.String)]
        public string Nome { get; set; }

        [BsonElement("Email"), BsonRepresentation(BsonType.String)]
        public string Email { get; set; }
    }
}
