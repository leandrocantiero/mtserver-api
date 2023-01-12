using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace mtvendors_api.Models
{
    [Table("cobranca")]
    public class Cobranca
    {
        [Key]
        
        [Column("codigo")]
        public int Codigo { get; set; } = 0;

        [Column("data")]
        public DateOnly Data { get; set; } = new DateOnly();

        [Column("fk_cliente_cnpj_cpf")]
        public int FkClienteCnpjCpf { get; set; } = 0;

        [Column("fk_empresa")]
        public int FkEmpresa { get; set; } = 0;

        [Column("fk_filial")]
        public int FkFilial { get; set; } = 0;

        [Column("fk_tipo_titulo")]
        public int FkTipoTitulo { get; set; } = 0;

        [Column("fk_titulo")]
        public int FkTitulo { get; set; } = 0;

        [Column("pgto_cheque")]
        public double PgtoCheque { get; set; } = 0;

        [Column("pgto_dinheiro")]
        public double PgtoDinheiro { get; set; } = 0;

        [Column("pgto_outras_especies")]
        public double PgtoOutrasEspecies { get; set; } = 0;

        [Column("pgto_ticket")]
        public double PgtoTicket { get; set; } = 0;

        [Column("valor_corrigido")]
        public double ValorCorrigido { get; set; } = 0;
    }
}
