using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;

namespace P1_Altair.Models
{
    public class Usuario
    {
        [BsonId]
        [BsonElement("Id"), BsonRepresentation(BsonType.String)]
        public string? Id { get; set; }
        [BsonElement("Nome"), BsonRepresentation(BsonType.String)]
        public string? Nome { get; set; }

        [BsonElement("Email"), BsonRepresentation(BsonType.String)]
        public string? Email { get; set; }
        [BsonElement("Password"), BsonRepresentation(BsonType.String)]
        [Required(ErrorMessage = "Senha obrigatória")]
        public string? Password { get; set; }
    }
}
