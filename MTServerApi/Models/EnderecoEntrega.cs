using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace mtvendors_api.Models
{
    [Table("enderecoentrega")]
    public class EnderecoEntrega
    {
        [Key]
        
        [Column("cep")]
        public int Cep { get; set; } = 0;

        [Column("endereco")]
        public string Endereco { get; set; } = "";

        [Column("bairro")]
        public string Bairro { get; set; } = "";

        [Column("complemento")]
        public string Complemento { get; set; } = "";

        [Column("sequencia")]
        public int Sequencia { get; set; } = 0;

        [Column("uf")]
        public string UF { get; set; } = "";

        [Column("cnpj")]
        public string cnpj { get; set; } = "";

        [Column("fk_cliente_cnpj_cpf")]
        public string FkClienteCnpjCpf { get; set; } = "";

        [Column("inscricao_estadual")]
        public string InscricaoEstadual { get; set; } = "";

        [Column("fk_codigo_cidade")]
        public string FkCodigoCidade { get; set; } = "";
    }
}
