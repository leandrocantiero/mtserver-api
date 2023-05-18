using mtvendors_api.Models.DAO;
using mtvendors_api.Models.Helpers;

namespace mtvendors_api.Models.DTO
{
    public class SincronizacaoDTO
    {
        public Schema Schema { get; set; }

        public string UpdateSchema { get; set; } = "";

        public int Version { get; set; }

        public SincronizacaoDTO(int version, Schema schema)
        {
            Schema = schema;
            UpdateSchema = "";
            Version = version;
        }
    }
}
