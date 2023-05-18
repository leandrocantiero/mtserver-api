using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace mtvendors_api.Models.DAO
{
    [Table("agendavisita")]
    public class AgendaVisita
    {
        [Key]
        [Column("codigo")]
        public int Codigo { get; set; } = 0;

        [Column("data_notificacao")]
        public DateOnly DataNotificacao { get; set; } = new DateOnly();

        [Column("data_visita")]
        public DateOnly DataVisita { get; set; } = new DateOnly();

        [Column("excluido")]
        public int Excluido { get; set; } = 0;

        [Column("fk_cliente_cnpj_cpf")]
        public int FkClienteCnpjCpf { get; set; } = 0;

        [Column("fk_vendedor")]
        public int fkVendedor { get; set; } = 0;

        [Column("horario")]
        public TimeOnly Horario { get; set; } = new TimeOnly();

        [Column("observacoes")]
        public string Observacoes { get; set; } = "";

        [Column("periodo_visita")]
        public string PeriodoVisita { get; set; } = "";

        [Column("sequencia")]
        public int Sequencia { get; set; } = 0;
    }
}
