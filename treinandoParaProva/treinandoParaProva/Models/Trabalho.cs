using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System.ComponentModel.DataAnnotations;

namespace treinandoParaProva.Models
{
    public class Trabalho
    {
            [BsonId]
            [BsonElement("Id"), BsonRepresentation(BsonType.String)]
            public string? Id { get; set; }
        
            [BsonElement("Titulo"), BsonRepresentation(BsonType.String)]
            public string? Titulo { get; set; }

            [BsonElement("Resumo"), BsonRepresentation(BsonType.String)]
            public string? Resumo { get; set; }

            [BsonElement("AreaTematica"), BsonRepresentation(BsonType.String)]
            public string? AreaTematica { get; set; }

            [BsonElement("DataSubmissao"), BsonRepresentation(BsonType.DateTime)]
            public DateTime DataSubmissao {  get; set; }
            public List<Autor>? Autores { get; set; }
            public List<Avaliacao>? Avaliacoes { get; set; }
            
    }
}
