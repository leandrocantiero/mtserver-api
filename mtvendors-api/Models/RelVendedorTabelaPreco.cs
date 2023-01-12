using System.ComponentModel.DataAnnotations.Schema;

namespace mtvendors_api.Models
{
    [Table("relvendedortabelapreco")]
    public class RelVendedorTabelaPreco
    {
        [Column("fk_empresa")]
        public int FkEmpresa { get; set; }

        [NotMapped]
        public string? Empresa { get; set; }

        [Column("fk_tabela_preco")]
        public string FkTabelaPreco { get; set; }

        [NotMapped]
        public string? TabelaPreco { get; set; }

        [Column("fk_vendedor")]
        public string FkVendedor { get; set; }

        [NotMapped]
        public string? Vendedor { get; set; }
    }
}
