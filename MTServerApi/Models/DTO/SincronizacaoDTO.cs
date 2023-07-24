using mtvendors_api.Models.DAO;
using mtvendors_api.Models.Helpers;

namespace mtvendors_api.Models.DTO
{
    public class SincronizacaoDTO
    {
        public Schema? Schema { get; set; }

        public int Version { get; set; }

        public string? Data { get; set; }
    }
}
