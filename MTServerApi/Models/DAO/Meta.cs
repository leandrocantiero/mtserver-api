using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace mtvendors_api.Models.DAO
{
    [Table("meta")]
    public class Meta
    {
        [Required(ErrorMessage = "O campo FkFilial é obrigatório")]
        [Column("fk_filial")]
        public int FkFilial { get; set; }

        [NotMapped]
        public string? Filial { get; set; }

        [Required(ErrorMessage = "O campo FkVendedor é obrigatório")]
        [Column("fk_vendedor")]
        [MaxLength(7)]
        public string FkVendedor { get; set; }

        [NotMapped]
        public string? Vendedor { get; set; }

        [Required(ErrorMessage = "O campo FkProduto é obrigatório")]
        [Column("fk_produto")]
        [MaxLength(20)]
        public string FkProduto { get; set; }

        [NotMapped]
        public string? Produto { get; set; }

        [Required(ErrorMessage = "O campo FkFamilia é obrigatório")]
        [Column("fk_familia")]
        [MaxLength(20)]
        public string FkFamilia { get; set; }

        [NotMapped]
        public string? FamiliaProduto { get; set; }

        [Required(ErrorMessage = "O campo FkClienteCnpjCpf é obrigatório")]
        [Column("fk_cliente_cnpj_cpf")]
        [MaxLength(14)]
        public string FkClienteCnpjCpf { get; set; }

        [NotMapped]
        public string? Cliente { get; set; }

        [Required(ErrorMessage = "O campo Periodo é obrigatório")]
        [Column("periodo")]
        public string Periodo { get; set; }

        [Required(ErrorMessage = "O campo Quantidade é obrigatório")]
        [Column("quantidade")]
        public double Quantidade { get; set; }

        [Required(ErrorMessage = "O campo Valor é obrigatório")]
        [Column("valor")]
        public double Valor { get; set; }
    }
}
