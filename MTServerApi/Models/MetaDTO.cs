namespace mtvendors_api.Models
{
    public class MetaDTO
    {
        public int FkFilial { get; set; }

        public string FkVendedor { get; set; }

        public string? Vendedor { get; set; }
        
        public string FkProduto { get; set; }

        public string? Produto { get; set; }

        public string FkFamilia { get; set; }

        public string? FamiliaProduto { get; set; }

        public string FkClienteCnpjCpf { get; set; }

        public string? Cliente { get; set; }

        public string Periodo { get; set; }

        public double Quantidade { get; set; }

        public double Valor { get; set; }
    }
}
