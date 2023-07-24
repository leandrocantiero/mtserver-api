using mtvendors_api.Models.DAO;
using System;

namespace mtvendors_api.Models.DTO
{
    public class AgendaVisitaDTO
    {
        public string? dataNotificacao { get; set; }
        public string? dataVisita { get; set; }
        public int excluido { get; set; } = 0;
        public string fkClienteCnpjCpf { get; set; }
        public string? fkVendedor { get; set; }
        public string? horario { get; set; }
        public string? observacoes { get; set; }
        public string periodoVisita { get; set; }
        public int sequencia { get; set; } = 0;

        public AgendaVisitaDTO(AgendaVisita agendaVisita)
        {
            dataNotificacao = agendaVisita.DataNotificacao != null ? agendaVisita.DataNotificacao.ToString() : null;
            dataVisita = agendaVisita.DataVisita != null ? agendaVisita.DataVisita.ToString() : null; 
            excluido = agendaVisita.Excluido;
            fkClienteCnpjCpf = agendaVisita.FkClienteCnpjCpf;
            fkVendedor = agendaVisita.fkVendedor;
            horario = agendaVisita.Horario != null ? agendaVisita.Horario.ToString() : null;
            observacoes = agendaVisita.Observacoes;
            periodoVisita = agendaVisita.PeriodoVisita;
            sequencia = agendaVisita.Sequencia;
        }
    }
}
