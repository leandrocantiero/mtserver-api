using System.ComponentModel.DataAnnotations.Schema;

namespace mtvendors_api.Models
{
    [Table("relcondpgtotabpreco")]
    public class RelCondPgtoTabelaPreco
    {
        [Column("fk_cliente_cnpj")]
        public string FkClienteCnpj { get; set; }

        [NotMapped]
        public string? Cliente { get; set; }

        [Column("fk_condicao_pgto")]
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
        public string FkTabelaPreco { get; set; }

        [NotMapped]
        public string? TabelaPreco { get; set; }

        [Column("fk_vendedor")]
        public string FkVendedor { get; set; }

        [NotMapped]
        public string? Vendedor { get; set; }

        [Column("incondicional")]
        public string Incondicional { get; set; }

        [Column("perc_desconto")]
        public double PercDesconto { get; set; }
    }
}
