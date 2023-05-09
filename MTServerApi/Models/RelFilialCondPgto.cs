using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace mtvendors_api.Models
{
    [Table("relfilialcondpgto")]
    public class RelFilialCondPgto
    {
        [Column("cod_empresa")]
        public int FkEmpresa { get; set; }

        [NotMapped]
        public string? Empresa { get; set; }

        [Column("cod_filial")]
        public int FkFilial { get; set; }

        [NotMapped]
        public string? Filial { get; set; }

        [Column("cod_condicao")]
        [MaxLength(10)]
        public string FkCondicaoPagamento { get; set; }

        [NotMapped]
        public string? CondicaoPagamento { get; set; }

        [Column("vlr_minimo")]
        public double ValorMin { get; set; }
    }
}
