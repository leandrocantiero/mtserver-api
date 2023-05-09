using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace mtvendors_api.Models
{
    [Table("cidade")]
    public class Cidade
    {
        [Key]
        
        [Column("codigo")]
        public int Codigo { get; set; } = 0;

        [Column("nome")]
        public string Nome { get; set; } = "";

        [Column("uf")]
        public string UF { get; set; } = "";
    }
}
