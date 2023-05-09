namespace mtvendors_api.Models.parameters
{
    public class EmpresaParameters : QueryStringParameters
    {
        public string? Nome { get; set; }

        public string? UF { get; set; }

        public string? FkEmpresa { get; set; }
    }
}
