using mtvendors_api.Models;
using mtvendors_api.Models.parameters;

namespace mtvendors_api.DAL.IRepository
{
    public interface IProdutoRepository : IDisposable
    {
        PagedResult<Produto> Get(ProdutoParameters parameters);
    }
}
