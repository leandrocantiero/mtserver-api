using mtvendors_api.DAL.IRepository;
using mtvendors_api.Models;
using mtvendors_api.Models.parameters;

namespace mtvendors_api.DAL.Repository
{
    public class TabelaPrecoRepository : ITabelaPrecoRepository
    {
        private DataContext context;

        public TabelaPrecoRepository(DataContext context)
        {
            this.context = context;
        }

        public PagedResult<TabelaPreco> Get(TabelaPrecoParameters parameters)
        {
            var result = new PagedResult<TabelaPreco>();
            var skip = (parameters.PageNumber - 1) * parameters.PageSize;
            var tabelas = context.TabelasPreco.ToList();

            result.Count = tabelas.Count;

            if (!string.IsNullOrEmpty(parameters.Descricao))
            {
                tabelas = tabelas.Where(o => o.Descricao != null && o.Descricao.ToUpper().Contains(parameters.Descricao.ToUpper())).ToList();
            }

            result.Data = tabelas.SortBy(parameters.OrderBy).Skip(skip).Take(parameters.PageSize).ToList();
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
