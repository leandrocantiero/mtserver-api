using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace mtvendors_api.Models
{
    [Table("condpgto")]
    public class CondPgto
    {
        [Key]
        [Column("codigo")]
        public string Codigo { get; set; }

        [Column("abreviatura")]
        public string Abreviatura { get; set; }

        [Column("descricao")]
        public string Descricao { get; set; }

        [Column("fk_empresa")]
        public int FkEmpresa { get; set; }

        [Column("quantidade_parcelas")]
        public int QuantidadeParcelas { get; set; }
    }
}
