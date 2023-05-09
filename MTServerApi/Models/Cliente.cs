using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace mtvendors_api.Models
{
    [Table("cliente")]
    public class Cliente
    {
        [Key]
        [Column("codigo")]
        public string? Codigo { get; set; }

        [Column("cnpj_cpf")]
        public string? CnpjCpf { get; set; }

        [Column("razao_social")]
        public string? RazaoSocial { get; set; }

        [Column("nome_fantasia")]
        public string? NomeFantasia { get; set; }

        [Column("inscr_estadual")]
        public string? InscrEstadual { get; set; }

        [Column("inscr_municipal")]
        public string? InscrMunicipal { get; set; }

        [Column("categoria")]
        public string? Categoria { get; set; }

        [Column("Contribuinte")]
        public string? Contribuinte { get; set; }

        [Column("email")]
        public string? Email { get; set; }

        [Column("fone_1")]
        public string? Fone_1 { get; set; }

        [Column("fone_2")]
        public string? Fone_2 { get; set; }

        [Column("fone_3")]
        public string? Fone_3 { get; set; }

        [Column("referencia")]
        public string? Referencia { get; set; }

        [Column("rota_entrega")]
        public string? RotaEntrega { get; set; }

        [Column("seq_rota_entrega")]
        public int? SeqRotaEntrega { get; set; }

        [Column("suframa")]
        public string? Suframa { get; set; }

        [Column("cidade")]
        public string? Cidade { get; set; }

        [Column("endereco")]
        public string? Endereco { get; set; }

        [Column("bairro")]
        public string? Bairro { get; set; }

        [Column("complemento")]
        public string? Complemento { get; set; }

        [Column("cep")]
        public int? Cep { get; set; }

        [Column("numero")]
        public int? Numero { get; set; }

        [Column("uf")]
        public string? UF { get; set; }

        [Column("endereco_cobranca")]
        public string? EnderecoCobranca { get; set; }

        [Column("bairro_cobranca")]
        public string? BairroCobranca { get; set; }

        [Column("complemento_cobranca")]
        public string? ComplementoCobranca { get; set; }

        [Column("ceo_cobranca")]
        public int? CepCobranca { get; set; }

        [Column("numero_cobranca")]
        public int? NumeroCobranca { get; set; }

        [Column("endereco_faturamento")]
        public string? EnderecoFaturamento { get; set; }

        [Column("bairro_faturamento")]
        public string? BairroFaturamento { get; set; }

        [Column("complemento_faturamento")]
        public string? ComplementoFaturamento { get; set; }

        [Column("cep_faturamento")]
        public int? CepFaturamento { get; set; }

        [Column("numero_faturamento")]
        public int? NumeroFaturamento { get; set; }

        [Column("endereco_entrega")]
        public string? EnderecoEntrega { get; set; }

        [Column("bairro_entrega")]
        public string? BairroEntrega { get; set; }

        [Column("complemento_entrega")]
        public string? ComplementoEntrega { get; set; }

        [Column("cep_entrega")]
        public int? CepEntrega { get; set; }

        [Column("numero_entrega")]
        public int? NumeroEntrega { get; set; }
    }
}
