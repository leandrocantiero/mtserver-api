using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace mtvendors_api.Models
{
    [Table("contatocliente")]
    public class ContatoCliente
    {
        [Key]
        
        [Column("codigo")]
        public int Codigo { get; set; } = 0;

        [Column("cargo")]
        public string Cargo { get; set; } = "";

        [Column("ddd")]
        public string DDD { get; set; } = "";

        [Column("departamento")]
        public string Departamento { get; set; } = "";

        [Column("email")]
        public string Email { get; set; } = "";

        [Column("fk_cliente_cnpj_cpf")]
        public string FkClienteCnpjCpf { get; set; } = "";

        [Column("nome")]
        public string Nome { get; set; } = "";

        [Column("ramal")]
        public int Ramal { get; set; } = 0;

        [Column("sequencia")]
        public int Sequencia { get; set; } = 0;

        [Column("telefone")]
        public string Telefone { get; set; } = "";
    }
}
