using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace mtvendors_api.Models.DAO
{
    [Table("evento")]
    public class Evento
    {
        [Key]
        [Column("codigo")]
        public int Codigo { get; set; } = 0;

        [Column("descricao")]
        public string Descricao { get; set; } = "";

        [Column("data_hora")]
        public DateTime DataHora { get; set; } = new DateTime();

        [Column("fk_tipo_evento")]
        public int FkTipoEvento { get; set; } = 0;

        [Column("fk_vendedor")]
        public string FkVendedor { get; set; } = "";

        [Column("visualizado")]
        public int Visualizado { get; set; } = 0;
    }
}
