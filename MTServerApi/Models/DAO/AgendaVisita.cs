using mtvendors_api.Models.Attributes;
using mtvendors_api.Models.Converters;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace mtvendors_api.Models.DAO
{
    [Table("agendavisita")]
    public class AgendaVisita
    {
        //[Key]
        //[Column("codigo")]
        //[Description("Código do agendamento")]
        //public int Codigo { get; set; } = 0;

        [Column("data_notificacao")]
        [Description("Data da notificação")]
        [JsonConverter(typeof(DateOnlyJsonConverter))]
        public DateOnly? DataNotificacao { get; set; }

        [Column("data_visita")]
        [Description("Data da visita")]
        [JsonConverter(typeof(DateOnlyJsonConverter))]
        public DateOnly? DataVisita { get; set; }

        [Column("excluido")]
        [Description("Flag que indica exclusão")]
        public int Excluido { get; set; } = 0;

        [Key]
        [Column("fk_cliente_cnpj_cpf")]
        [Description("CNPJ/CPF do cliente")]
        public string FkClienteCnpjCpf { get; set; }

        [Column("fk_vendedor")]
        [Description("Código do vendedor")]
        public string? fkVendedor { get; set; }

        [Column("horario")]
        [Description("Horário do agendamento")]
        [JsonConverter(typeof(TimeOnlyJsonConverter))]
        public TimeOnly? Horario { get; set; }

        [Column("observacoes")]
        [Description("Observações do agendamento")]
        [Size(255)]
        public string? Observacoes { get; set; }

        [Column("periodo_visita")]
        [Description("Período do agendamento")]
        [Size(50)]
        public string PeriodoVisita { get; set; }

        [Column("sequencia")]
        [Description("Sequência do agendamento")]
        public int Sequencia { get; set; } = 0;
    }
}
