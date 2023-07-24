using mtvendors_api.Models.Attributes;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace mtvendors_api.Models.DAO
{
    [Table("cidade")]
    public class Cidade
    {
        [Key]
        [Column("codigo")]
        [Description("Código IBGE da cidade")]
        public int Codigo { get; set; } = 0;

        [Column("nome")]
        [Description("Nome da cidade")]
        [Size(50)]
        public string Nome { get; set; } = "";

        [Column("uf")]
        [Description("UF da cidade")]
        [Size(2)]
        public string UF { get; set; } = "";
    }
}