using Microsoft.EntityFrameworkCore;
using mtvendors_api.DAL.IRepository;
using mtvendors_api.Models;
using mtvendors_api.Models.parameters;
using static System.Net.Mime.MediaTypeNames;

namespace mtvendors_api.DAL.Repository
{
    public class SituacaoRepository : ISituacaoRepository
    {
        private DataContext context;

        public SituacaoRepository(DataContext context)
        {
            this.context = context;
        }

        public void Insert(SituacaoPedido situacao)
        {
            context.SituacoesPedido.Add(situacao);
        }

        public void Update(SituacaoPedido situacao)
        {
            context.Entry(situacao).State = EntityState.Modified;
        }

        public PagedResult<SituacaoPedido> Get(SituacaoPedidoParameters parameters)
        {
            var result = new PagedResult<SituacaoPedido>();
            var skip = (parameters.PageNumber - 1) * parameters.PageSize;
            var situacoes = context.SituacoesPedido.ToList();

            result.Count = situacoes.Count;

            if (!string.IsNullOrEmpty(parameters.Descricao))
            {
                situacoes = situacoes.Where(o => o.Descricao.ToUpper().Contains(parameters.Descricao.ToUpper())).ToList();
            }

            result.Data = situacoes.SortBy(parameters.OrderBy).Skip(skip).Take(parameters.PageSize).ToList();
            return result;
        }

        public SituacaoPedido? GetByCodigo(int codigo)
        {
            return context.SituacoesPedido.Find(codigo);
        }

        public void Remove(int codigo)
        {
            var situacao = context.SituacoesPedido.Find(codigo);
            context.SituacoesPedido.Remove(situacao);
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
