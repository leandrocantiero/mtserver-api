using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace mtvendors_api.Models
{
    [Table("imagem")]
    public class Imagem
    {
        [Key]
        
        [Column("nome")]
        [Required(ErrorMessage = "O campo Nome é obrigatório")]
        public string Nome { get; set; }

        [Column("data")]
        [JsonConverter(typeof(DateOnlyJsonConverter))]
        public DateOnly Data { get; set; }

        [Column("hora")]
        [JsonConverter(typeof(TimeOnlyJsonConverter))]
        public TimeOnly Hora { get; set; }

        [Column("hash")]
        public string Hash { get; set; }

        [Column("is_atualizado")]
        public bool IsAtualizado { get; set; } = false;

        public override string ToString()
        {
            return Nome + Data + Hora;
        }
    }
}
