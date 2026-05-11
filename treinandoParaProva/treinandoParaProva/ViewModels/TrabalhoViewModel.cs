namespace treinandoParaProva.ViewModels
{
    public class TrabalhoViewModel //não são necessários na ViewModel. Bson, pois ela não se relaciona com MongoDB
    {
        public string? Id { get; set; }

        public string? Titulo { get; set; }

        public string? AreaTematica { get; set; }

        public int QuantidadeAutores { get; set; }

        public double MediaNotas { get; set; }
    }
}
