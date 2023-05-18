using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace mtvendors_api.Models.DAO
{
    [Table("titulo")]
    public class Titulo
    {
        [Key]

        [Column("codigo")]
        public string Codigo { get; set; } = "";

        [Column("fk_empresa")]
        public int FkEmpresa { get; set; } = 0;

        [Column("fk_filial")]
        public int FkFilial { get; set; } = 0;

        [Column("tipo_titulo")]
        public string TipoTitulo { get; set; } = "";

        [Column("data_vencimento")]
        public DateOnly DataVencimento { get; set; } = new DateOnly();

        [Column("valor_original")]
        public double ValorOriginal { get; set; } = 0;

        [Column("percentual_juros_dia")]
        public double PercentualJurosDia { get; set; } = 0;

        [Column("valor_juros_dia")]
        public double ValorJurosDia { get; set; } = 0;

        [Column("valor_multa")]
        public double ValorMulta { get; set; } = 0;

        [Column("fk_cliente_cnpj_cpf")]
        public string FkClienteCnpjCpf { get; set; } = "";
    }
}
