using Microsoft.EntityFrameworkCore;
using mtvendors_api.DAL.IRepository;
using mtvendors_api.Models.DAO;
using mtvendors_api.Models.Helpers;
using mtvendors_api.Models.parameters;

namespace mtvendors_api.DAL.Repository
{
    public class JustificativaRepository : IJustificativaRepository
    {
        private DataContext context;

        public JustificativaRepository(DataContext context)
        {
            this.context = context;
        }

        public void Insert(JustificativaPedido justificativa)
        {
            context.JustificativasPedido.Add(justificativa);
        }

        public void Update(JustificativaPedido justificativa)
        {
            context.Entry(justificativa).State = EntityState.Modified;
        }

        public JustificativaPedido? GetByCodigo(int codigo)
        {
            return context.JustificativasPedido.Find(codigo);
        }

        public PagedResult<JustificativaPedido> Get(JustificativaPedidoParameters parameters)
        {
            var result = new PagedResult<JustificativaPedido>();
            var skip = (parameters.PageNumber - 1) * parameters.PageSize;
            var justificativas = context.JustificativasPedido.ToList();

            result.Count = justificativas.Count;

            if (!string.IsNullOrEmpty(parameters.Descricao))
            {
                justificativas = justificativas.Where(o => o.Descricao.ToUpper().Contains(parameters.Descricao.ToUpper())).ToList();
            }

            result.Data = justificativas.SortBy(parameters.OrderBy).Skip(skip).Take(parameters.PageSize).ToList();
            return result;
        }

        public void Remove(int codigo)
        {
            var justificativa = context.JustificativasPedido.Find(codigo);
            context.JustificativasPedido.Remove(justificativa);
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
