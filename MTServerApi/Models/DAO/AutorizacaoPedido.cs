using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace mtvendors_api.Models.DAO
{
    [Table("autorizacaopedido")]
    public class AutorizacaoPedido
    {
        [Key]

        [Column("nr_pedido_palm")]
        public string NrPedidoPalm { get; set; } = "";

        [Column("fk_vendedor")]
        public int CodVendedor { get; set; } = 0;

        [Column("data_requisicao")]
        public DateOnly DataRequisicao { get; set; } = new DateOnly();

        [Column("situacao")]
        public int Situacao { get; set; } = 0;

        [Column("observacao")]
        public string Observacao { get; set; } = "";
    }
}
