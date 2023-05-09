using mtvendors_api.DAL.IRepository;
using mtvendors_api.Models;
using mtvendors_api.Models.parameters;
using static System.Net.Mime.MediaTypeNames;

namespace mtvendors_api.DAL.Repository
{
    public class CondPgtoRepository : ICondPgtoRepository
    {
        private DataContext context;

        public CondPgtoRepository(DataContext context)
        {
            this.context = context;
        }

        public PagedResult<CondPgto> Get(CondPgtoParameters parameters)
        {
            var result = new PagedResult<CondPgto>();
            var skip = (parameters.PageNumber - 1) * parameters.PageSize;
            var list = context.CondPgtos.ToList();

            result.Count = list.Count;

            if (!string.IsNullOrEmpty(parameters.Descricao))
            {
                list = list.Where(o => o.Descricao != null && o.Descricao.ToUpper().Contains(parameters.Descricao.ToUpper())).ToList();
            }

            if (!string.IsNullOrEmpty(parameters.Abreviatura))
            {
                list = list.Where(o => o.Abreviatura != null && o.Abreviatura.ToUpper().Contains(parameters.Abreviatura.ToUpper())).ToList();
            }

            result.Data = list.SortBy(parameters.OrderBy).Skip(skip).Take(parameters.PageSize).ToList();
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
