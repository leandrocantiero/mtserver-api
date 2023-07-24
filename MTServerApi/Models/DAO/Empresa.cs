using mtvendors_api.Models.Attributes;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace mtvendors_api.Models.DAO
{
    [Table("empresa")]
    public class Empresa
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
