using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace mtvendors_api.Models.DAO
{
    [Table("Produto")]
    public class Produto
    {
        [Key]
        [Column("codigo")]
        public string? Codigo { get; set; }

        [Column("descricao")]
        public string? Descricao { get; set; }

        [Column("descricao_produto")]
        public string? DescricaoProduto { get; set; }

        [Column("bloqueado")]
        public string? Bloqueado { get; set; }

        [Column("fk_unidade_medida")]
        public string? FkUnidadeMedida { get; set; }

        [Column("fk_familia")]
        public string? FkFamilia { get; set; }

        [Column("fk_natureza_operacao")]
        public string? FkNaturezaOperacao { get; set; }

        [Column("fk_empresa")]
        public int? FkEmpresa { get; set; }

        [Column("fk_grade1")]
        public int? FkGrade1 { get; set; }

        [Column("fk_grade2")]
        public int? FkGrade2 { get; set; }

        [Column("fk_grade3")]
        public int? FkGrade3 { get; set; }

        [Column("qtd_embalagem")]
        public double QtdEmbalagem { get; set; }

        [Column("qtd_mult_vendas")]
        public double QtdMultVendas { get; set; }

        [Column("peso_bruto")]
        public double PesoBruto { get; set; }

        [Column("aliquota_ipi")]
        public double AliquotaIpi { get; set; }

        [Column("cmv")]
        public double CMV { get; set; }
    }
}
