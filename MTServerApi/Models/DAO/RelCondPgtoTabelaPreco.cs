using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace mtvendors_api.Models.DAO
{
    [Table("relcondpgtotabpreco")]
    public class RelCondPgtoTabelaPreco
    {
        [Column("fk_cliente_cnpj")]
        [MaxLength(14)]
        public string FkClienteCnpj { get; set; }

        [NotMapped]
        public string? Cliente { get; set; }

        [Column("fk_condicao_pgto")]
        [MaxLength(10)]
        public string FkCondicaoPagamento { get; set; }

        [NotMapped]
        public string? CondicaoPagamento { get; set; }

        [Column("fk_empresa")]
        public int FkEmpresa { get; set; }

        [NotMapped]
        public string? Empresa { get; set; }

        [Column("fk_filial")]
        public int FkFilial { get; set; }

        [NotMapped]
        public string? Filial { get; set; }

        [Column("fk_tabela_preco")]
        [MaxLength(10)]
        public string FkTabelaPreco { get; set; }

        [NotMapped]
        public string? TabelaPreco { get; set; }

        [Column("fk_vendedor")]
        [MaxLength(7)]
        public string FkVendedor { get; set; }

        [NotMapped]
        public string? Vendedor { get; set; }

        [Column("incondicional")]
        public string Incondicional { get; set; }

        [Column("perc_desconto")]
        public double PercDesconto { get; set; }
    }
}
