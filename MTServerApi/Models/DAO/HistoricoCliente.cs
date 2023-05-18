using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace mtvendors_api.Models.DAO
{
    [Table("historicocliente")]
    public class HistoricoCliente
    {
        [Key]

        [Column("nr_pedido_palm")]
        public string NrPedidoPalm { get; set; } = "";

        [Column("limite_credito")]
        public double LimiteCredito { get; set; } = 0;

        [Column("situacao_cliente")]
        public string SituacaoCliente { get; set; } = "";

        [Column("fk_cliente_cnpj_cpf")]
        public int FkClienteCnpjCpf { get; set; } = 0;

        [Column("fk_cond_pgto")]
        public int FkCondPgto { get; set; } = 0;

        [Column("fk_empresa")]
        public int FkEmpresa { get; set; } = 0;

        [Column("fk_filial")]
        public int FkFilial { get; set; } = 0;

        [Column("fk_forma_pgto")]
        public int FkFormaPgto { get; set; } = 0;

        [Column("fk_oper_comercial")]
        public int FkOperComercial { get; set; } = 0;

        [Column("fk_tipo_cobranca")]
        public int FkTipoCobranca { get; set; } = 0;

        [Column("fk_transportadora")]
        public int FkTransportadora { get; set; } = 0;

        [Column("fk_vendedor")]
        public int FkVendedor { get; set; } = 0;

        [Column("cod_categoria1")]
        public string CodCategoria1 { get; set; } = "";

        [Column("cod_categoria2")]
        public string CodCategoria2 { get; set; } = "";

        [Column("cod_categoria3")]
        public string CodCategoria3 { get; set; } = "";
    }
}
