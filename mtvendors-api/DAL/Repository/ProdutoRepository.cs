using mtvendors_api.DAL.IRepository;
using mtvendors_api.Models;
using mtvendors_api.Models.parameters;
using static System.Net.Mime.MediaTypeNames;

namespace mtvendors_api.DAL.Repository
{
    public class ProdutoRepository : IProdutoRepository
    {
        private DataContext context;

        public ProdutoRepository(DataContext context)
        {
            this.context = context;
        }

        public PagedResult<Produto> Get(ProdutoParameters parameters)
        {
            var result = new PagedResult<Produto>();
            var skip = (parameters.PageNumber - 1) * parameters.PageSize;
            var produtos = context.Produtos.ToList();

            result.Count = produtos.Count;

            if (!string.IsNullOrEmpty(parameters.Descricao))
            {
                produtos = produtos.Where(o => o.Descricao != null && o.Descricao.ToUpper().Contains(parameters.Descricao.ToUpper())).ToList();
            }

            result.Data = produtos.SortBy(parameters.OrderBy).Skip(skip).Take(parameters.PageSize).ToList();
            return result;
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
