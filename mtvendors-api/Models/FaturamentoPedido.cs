using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace mtvendors_api.Models
{
    [Table("faturamentopedido")]
    public class FaturamentoPedido
    {
        [Key]
        
        [Column("nr_pedido_palm")]
        public string NrPedidoPalm { get; set; } = "";

        [Column("nr_pedido_retaguarda")]
        public string NrPedidoRetaguarda { get; set; } = "";

        [Column("data_faturamento")]
        public DateOnly DataFaturamento { get; set; } = new DateOnly();

        [Column("fk_empresa")]
        public int FkEmpresa { get; set; } = 0;

        [Column("fk_filial")]
        public int FkFilial { get; set; } = 0;

        [Column("fk_vendedor")]
        public string FkVendedor { get; set; } = "";

        [Column("fk_produto")]
        public string Fk_Produto { get; set; } = "";

        [Column("fk_item_grade1")]
        public string FkItemGrade1 { get; set; } = "";

        [Column("fk_item_grade2")]
        public string FkItemGrade2 { get; set; } = "";

        [Column("fk_item_grade3")]
        public string FkItemGrade3 { get; set; } = "";

        [Column("numero_nf")]
        public int NumeroNf { get; set; } = 0;

        [Column("quantidade_faturada")]
        public double QuantidadeFaturada { get; set; } = 0;

        [Column("seq_item_nf")]
        public int SeqItemNf { get; set; } = 0;

        [Column("serie_nf")]
        public string SerieNf { get; set; } = "";
    }
}
