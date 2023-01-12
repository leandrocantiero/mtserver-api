using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace mtvendors_api.Models
{
    [Table("vendedor")]
    public class Vendedor
    {
        [Key]
        
        [Column("codigo")]
        [Required(ErrorMessage = "O campo Codigo é obrigatório")]
        public string Codigo { get; set; }

        [Column("senha")]
        public string? Senha { get; set; }

        [Column("nome")]
        public string? Nome { get; set; }

        [Column("email")]
        public string? Email { get; set; }

        [Column("tipo")]
        public string? Tipo { get; set; }

        [Column("senha_caixa_postal")]
        public string? SenhaCaixaPostal { get; set; }

        [Column("codigo_supervisor")]
        public string? CodigoSupervisor { get; set; } = "";

        [NotMapped]
        public string? Supervisor { get; set; }

        [Column("atualiza_saldoflex")]
        public string? AtualizaSaldoFlex { get; set; } = "";

        [Column("sys_restore_tablet")]
        public int? SysRestoreTablet { get; set; } = 0;

        [NotMapped]
        public string Token { get; set; } = "";
    }
}
