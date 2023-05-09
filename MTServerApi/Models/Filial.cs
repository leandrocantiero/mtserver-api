using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace mtvendors_api.Models
{
    [Table("filial")]
    public class Filial
    {
        [Key]
        [Column("codigo")]
        public int Codigo { get; set; }

        [Column("nome")]
        public string? Nome { get; set; }

        [Column("uf")]
        public string? UF { get; set; }

        [Column("fk_empresa")]
        public int FkEmpresa { get; set; }
    }
}
