using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace mtvendors_api.Models.DAO
{
    [Table("enderecocobranca")]
    public class EnderecoCobranca
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

        [Column("cnpj_cobranca")]
        public string cnpj_cobranca { get; set; } = "";

        [Column("fk_cliente_cnpj_cpf")]
        public string FkClienteCnpjCpf { get; set; } = "";

        [Column("fk_codigo_cidade")]
        public string FkCodigoCidade { get; set; } = "";
    }
}
