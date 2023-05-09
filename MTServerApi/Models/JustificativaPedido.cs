using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace mtvendors_api.Models
{
    [Table("justificativa")]
    public class JustificativaPedido
    {
        [Key]
        [Column("codigo")]
        public int Codigo { get; set; }

        [Required(ErrorMessage = "O campo Descricao é obrigatório")]
        [Column("descricao")]
        public string Descricao { get; set; } = "";
    }
}
