using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace mtvendors_api.Models
{
    [Table("estoquedisponivel")]
    public class EstoqueDisponivel
    {
        [Key]
        
        [Column("codigo_local_armazenamento")]
        public string CodigoLocalArmazenamento { get; set; } = "";

        [Column("fk_empresa")]
        public int FkEmpresa { get; set; } = 0;

        [Column("fk_filial")]
        public int fkFilial { get; set; } = 0;

        [Column("fk_item_grade1")]
        public string fkItemGrade1 { get; set; } = "";

        [Column("fk_item_grade2")]
        public string fkItemGrade2 { get; set; } = "";

        [Column("fk_item_grade3")]
        public string fkItemGrade3 { get; set; } = "";

        [Column("fk_produto")]
        public string fkProduto { get; set; } = "";

        [Column("quantidade")]
        public double Quantidade { get; set; } = 0;
    }
}
