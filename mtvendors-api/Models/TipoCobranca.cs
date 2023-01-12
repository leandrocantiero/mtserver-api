using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace mtvendors_api.Models
{
    [Table("tipocobranca")]
    public class TipoCobranca
    {
        [Key]
        
        [Column("codigo")]
        public string Codigo { get; set; } = "";

        [Column("fk_empresa")]
        public int FkEmpresa { get; set; } = 0;

        [Column("descricao")]
        public string Descricao { get; set; } = "";
    }
}
