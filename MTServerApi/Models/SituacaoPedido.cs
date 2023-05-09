using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace mtvendors_api.Models
{
    [Table("situacaopedido")]
    public class SituacaoPedido
    {
        [Key]
        
        [Required(ErrorMessage = "O campo Codigo é obrigatório")]
        [Column("codigo")]
        public int Codigo { get; set; } = 0;

        [Required(ErrorMessage = "O campo Descricao é obrigatório")]
        [Column("descricao")]
        public string Descricao { get; set; } = "";
    }
}
