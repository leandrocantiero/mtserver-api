namespace mtvendors_api.Models.parameters
{
    public class VendedorParameters : QueryStringParameters
    {
        public string? Nome { get; set; }

        public string? Email { get; set; }

        public bool? SupervisorsOnly { get; set; }

        public string? NomeOrEmail { get; set; }

        public string? CodigoSupervisor { get; set; }
    }
}
