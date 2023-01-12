using mtvendors_api.Models;
using mtvendors_api.Models.parameters;

namespace mtvendors_api.DAL.IRepository
{
    public interface IClienteRepository : IDisposable
    {
        PagedResult<Cliente> Get(ClienteParameters parameters);

        Cliente? GetByCodigo(string cnpjCpf);
    }
}
