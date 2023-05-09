using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace mtvendors_api.Models
{
    [Table("tabelapreco")]
    public class TabelaPreco
    {
        [Key]
        [Column("codigo")]
        public string Codigo { get; set; }

        [Column("fk_empresa")]
        public int FkEmpresa { get; set; }

        [Column("descricao")]
        public string Descricao { get; set; }

        [Column("especial_cliente")]
        public string EspecialCliente { get; set; }

        [Column("promocional")]
        public string? Promocional { get; set; }
    }
}
