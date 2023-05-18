using mtvendors_api.DAL.IRepository;
using mtvendors_api.Models.DAO;
using mtvendors_api.Models.Helpers;
using mtvendors_api.Models.parameters;

namespace mtvendors_api.DAL.Repository
{
    public class FamiliaRepository : IFamiliaRepository
    {
        private DataContext context;

        public FamiliaRepository(DataContext context)
        {
            this.context = context;
        }

        public PagedResult<FamiliaProduto> Get(QueryStringParameters parameters)
        {
            var result = new PagedResult<FamiliaProduto>();
            var skip = (parameters.PageNumber - 1) * parameters.PageSize;
            var familias = context.FamiliaProdutos.ToList();

            result.Count = familias.Count;

            result.Data = familias.SortBy(parameters.OrderBy).Skip(skip).Take(parameters.PageSize).ToList();

            return result;
        }

        public FamiliaProduto? GetByCodigo(string codigo)
        {
            return context.FamiliaProdutos.Find(codigo);
        }

        private bool Disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!Disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            Disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
