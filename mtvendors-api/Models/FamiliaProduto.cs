using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace mtvendors_api.Models
{
    [Table("familiaproduto")]
    public class FamiliaProduto
    {
        [Key]
        
        [Column("codigo")]
        public string? Codigo { get; set; }

        [Column("descricao")]
        public string? Descricao { get; set; }

        [Column("fk_empresa")]
        public int? FkEmpresa { get; set; }
    }
}
