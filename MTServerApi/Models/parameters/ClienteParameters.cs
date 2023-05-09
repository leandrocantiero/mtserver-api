namespace mtvendors_api.Models.parameters
{
    public class ClienteParameters : QueryStringParameters
    {
        public string? NomeOrEmail { get; set; }

        public string? RazaoSocial { get; set; }

        public string? CnpjCpf { get; set; }
    }
}
