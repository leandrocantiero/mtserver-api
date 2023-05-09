using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace mtvendors_api.Models
{
    [Table("pedido")]
    public class Pedido
    {
        [Key]
        
        [Column("nr_pedido_palm")]
        public string NrPedidoPalm { get; set; } = "";

        [Column("nr_pedido_retaguarda")]
        public string NrPedidoRetaguarda { get; set; } = "";

        [Column("nr_pedido_cliente")]
        public string NrPedidoCliente { get; set; } = "";

        [Column("situacao_pedido")]
        public int SituacaoPedido { get; set; } = 0;

        [Column("data_emissao")]
        public DateOnly DataEmissao { get; set; } = new DateOnly();

        [Column("hora_emissao")]
        public TimeOnly HoraEmissao { get; set; } = new TimeOnly();

        [Column("data_entrega")]
        public DateOnly DataEntrega { get; set; } = new DateOnly();

        [Column("desconto1")]
        public double Desconto1 { get; set; } = 0;

        [Column("desconto2")]
        public double Desconto2 { get; set; } = 0;

        [Column("desconto3")]
        public double Desconto3 { get; set; } = 0;

        [Column("desconto4")]
        public double Desconto4 { get; set; } = 0;

        [Column("peso_bruto")]
        public double PesoBruto { get; set; } = 0;

        [Column("valor_bruto")]
        public double ValorBruto { get; set; } = 0;

        [Column("valor_frete")]
        public double ValorFrete { get; set; } = 0;

        [Column("valor_frete_tonelada")]
        public double ValorFreteTonelada { get; set; } = 0;

        [Column("fk_cliente_cnpj_cpf")]
        public int FkClienteCnpjCpf { get; set; } = 0;

        [Column("fk_cond_pgto")]
        public int FkCondPgto { get; set; } = 0;

        [Column("fk_contato")]
        public int FkContato { get; set; } = 0;

        [Column("fk_empresa")]
        public int FkEmpresa { get; set; } = 0;

        [Column("fk_filial")]
        public int FkFilial { get; set; } = 0;

        [Column("fk_end_cobranca")]
        public int FkEndCobranca { get; set; } = 0;

        [Column("fk_end_entrega")]
        public int FkEndEntrega { get; set; } = 0;

        [Column("fk_forma_pgto")]
        public int FkFormaPgto { get; set; } = 0;

        [Column("fk_nat_oper")]
        public int FkNatOper { get; set; } = 0;

        [Column("fk_oper_comercial")]
        public int FkOperComercial { get; set; } = 0;

        [Column("fk_tipo_cobranca")]
        public int FkTipoCobranca { get; set; } = 0;

        [Column("fk_tipo_frete")]
        public int FkTipoFrete { get; set; } = 0;

        [Column("fk_transportadora")]
        public int FkTransportadora { get; set; } = 0;

        [Column("fk_vendedor")]
        public int FkVendedor { get; set; } = 0;

        [Column("obs_pedido")]
        public string ObsPedido { get; set; } = "";

        [Column("cod_categoria1")]
        public string CodCategoria1 { get; set; } = "";

        [Column("cod_categoria2")]
        public string CodCategoria2 { get; set; } = "";

        [Column("cod_categoria3")]
        public string CodCategoria3 { get; set; } = "";
    }
}
