using mtvendors_api.Models.DAO;
using mtvendors_api.Models.Helpers;
using mtvendors_api.Models.parameters;

namespace mtvendors_api.DAL.IRepository
{
    public interface IVendedorRepository : IDisposable
    {
        void Insert(Vendedor vendedor);

        void Update(Vendedor vendedor);

        PagedResult<Vendedor> Get(VendedorParameters parameters);

        Vendedor? GetByCodigo(string codigo);

        Vendedor? GetByAuth(string codigo, string senha);

        void Remove(string codigo);

        void Save();
    }
}
