using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace mtvendors_api.Models.DAO
{
    [Table("sys_config")]
    public class SysConfig
    {
        [Key]
        public int Version { get; set; }
    }
}
