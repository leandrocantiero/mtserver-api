using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace mtvendors_api.Models
{
    [Table("transportadora")]
    public class Transportadora
    {
        [Key]
        
        [Column("codigo")]
        public string Codigo { get; set; } = "";

        [Column("descricao")]
        public string Descricao { get; set; } = "";

        [Column("cnpj")]
        public string Cnpj { get; set; } = "";

        [Column("cidade")]
        public string Cidade { get; set; } = "";

        [Column("uf")]
        public string Uf { get; set; } = "";
    }
}
