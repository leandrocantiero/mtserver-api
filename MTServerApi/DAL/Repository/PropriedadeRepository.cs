using Microsoft.EntityFrameworkCore;
using mtvendors_api.DAL.IRepository;
using mtvendors_api.Models;
using mtvendors_api.Models.parameters;

namespace mtvendors_api.DAL.Repository
{
    public class PropriedadeRepository : IPropriedadeRepository
    {
        private DataContext context;

        public PropriedadeRepository(DataContext context)
        {
            this.context = context;
        }

        public void Update(Propriedade propriedade)
        {
            context.Entry(propriedade).State = EntityState.Modified;
        }

        public PagedResult<Propriedade> Get(PropriedadeParameters parameters)
        {
            var result = new PagedResult<Propriedade>();
            var skip = (parameters.PageNumber - 1) * parameters.PageSize;
            var props = context.Propriedades.ToList();

            result.Count = props.Count;

            if (!string.IsNullOrEmpty(parameters.Nome))
            {
                props = props.Where(o => o.Nome.ToUpper().Contains(parameters.Nome.ToUpper())).ToList();
            }

            if (!string.IsNullOrEmpty(parameters.Descricao))
            {
                props = props.Where(o => o.Descricao.ToUpper().Contains(parameters.Descricao.ToUpper())).ToList();
            }

            result.Data = props.SortBy(parameters.OrderBy).Skip(skip).Take(parameters.PageSize).ToList();
            return result;
        }

        public Propriedade? GetByNome(string nome)
        {
            return context.Propriedades.Find(nome);
        }

        public void Save()
        {
            context.SaveChanges();
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
