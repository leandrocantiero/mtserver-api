using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace mtvendors_api.Models.DAO
{
    [Table("relclientetabelapreco")]
    public class RelClienteTabelaPreco
    {
        [Column("fk_cliente_cpf_cnpj")]
        [MaxLength(14)]
        public string FkClienteCpfCnpj { get; set; }

        [NotMapped]
        public string? Cliente { get; set; }

        [Column("fk_empresa")]
        public int FkEmpresa { get; set; }

        [NotMapped]
        public string? Empresa { get; set; }

        [Column("fk_filial")]
        public int FkFilial { get; set; }

        [NotMapped]
        public string? Filial { get; set; }

        [Column("fk_tabela_preco")]
        [MaxLength(10)]
        public string FkTabelaPreco { get; set; }

        [NotMapped]
        public string? TabelaPreco { get; set; }
    }
}
