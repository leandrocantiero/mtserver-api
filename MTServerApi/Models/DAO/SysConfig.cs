using mtvendors_api.Models.Helpers;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace mtvendors_api.Models.DAO
{
    [Table("sys_config")]
    public class SysConfig
    {
        [Key]
        [Column("version")]
        public int Version { get; set; }

        [Column("schema")]
        public string? Schema { get; set; } = "{}";
    }
}
