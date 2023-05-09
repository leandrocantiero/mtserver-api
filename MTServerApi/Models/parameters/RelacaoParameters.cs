namespace mtvendors_api.Models.parameters
{
    public class RelacaoParameters : QueryStringParameters
    {
        public string? Empresa { get; set; }

        public string? Filial { get; set; }

        public string? Condicao { get; set; }

        public string? Cliente { get; set; }

        public string? Vendedor { get; set; }

        public string? TabelaPreco { get; set; }
    }
}
