using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace mtvendors_api.Models
{
    [Table("formapgto")]
    public class FormaPagamento
    {
        [Key]
        
        [Column("codigo")]
        public int Codigo { get; set; }

        [Column("fk_empresa")]
        public int FkEmpresa { get; set; }

        [Column("abreviatura")]
        public int Abreviatura { get; set; }
    }
}
