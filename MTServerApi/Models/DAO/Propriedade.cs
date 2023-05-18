using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace mtvendors_api.Models.DAO
{
    [Table("propriedades")]
    public class Propriedade
    {
        [Key]

        [Column("nome")]
        [Required(ErrorMessage = "O campo Nome é obrigatório")]
        public string Nome { get; set; }

        [Column("descricao")]
        public string Descricao { get; set; }

        [Column("valor")]
        [Required(ErrorMessage = "O campo Valor é obrigatório")]
        public string Valor { get; set; }

        [Column("sequencia")]
        public int Sequencia { get; set; }
    }
}
