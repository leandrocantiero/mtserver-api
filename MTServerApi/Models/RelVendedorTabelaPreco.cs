using System.ComponentModel.DataAnnotations;
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
        [MaxLength(10)]
        public string FkTabelaPreco { get; set; }

        [NotMapped]
        public string? TabelaPreco { get; set; }

        [Column("fk_vendedor")]
        [MaxLength(7)]
        public string FkVendedor { get; set; }

        [NotMapped]
        public string? Vendedor { get; set; }
    }
}
