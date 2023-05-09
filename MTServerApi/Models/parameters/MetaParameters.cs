namespace mtvendors_api.Models.parameters
{
    public class MetaParameters : QueryStringParameters
    {
        public int? FkFilial { get; set; }

        public string? FkVendedor { get; set; }

        public string? FkClienteCnpjCpf { get; set; }

        public string? FkProduto { get; set; }

        public string? FkFamilia { get; set; }

        public string? Periodo { get; set; }

        public bool IsParametersValid => FkVendedor != null && FkFilial != null && FkClienteCnpjCpf != null && FkProduto != null && FkFamilia != null;
    }
}
