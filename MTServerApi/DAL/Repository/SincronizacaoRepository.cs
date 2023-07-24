using mtvendors_api.DAL.IRepository;
using mtvendors_api.Models.DAO;
using mtvendors_api.Models.DTO;
using System.Dynamic;
using System.Text.Encodings.Web;
using System.Text.Json;

namespace mtvendors_api.DAL.Repository
{
    public class SincronizacaoRepository : ISincronizacaoRepository
    {
        DataContext context;
        public SincronizacaoRepository(DataContext context)
        {
            this.context = context;
        }

        public string GetData(bool databaseFileExists)
        {
            var result = new {
                agendaVisitas = context.AgendaVisitas.Select(i => new AgendaVisitaDTO(i)).ToList(),
                cidades = !databaseFileExists ? context.Cidades.ToList() : null,
            };

            return JsonSerializer.Serialize(result, new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping
            });
        }

        public SysConfig? GetSysConfig() {
            return context.SysConfig.FirstOrDefault();
        }
    }
}
