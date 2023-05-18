using Microsoft.EntityFrameworkCore;
using mtvendors_api.Models.DAO;
using mtvendors_api.Models.Helpers;
using mtvendors_api.Models.parameters;
using System.Collections.Generic;

namespace mtvendors_api.DAL.IRepository
{
    public class RelFilialCondPgtoRepository : IRelFilialCondPgtoRepository
    {
        private DataContext context;

        public RelFilialCondPgtoRepository(DataContext context)
        {
            this.context = context;
        }

        public void Insert(RelFilialCondPgto relacao)
        {
            context.RelFilialCondPgtos.Add(relacao);
        }

        public void Update(RelFilialCondPgto relacao)
        {
            context.Entry(relacao).State = EntityState.Modified;
        }

        public PagedResult<RelFilialCondPgto> Get(RelacaoParameters parameters)
        {
            var result = new PagedResult<RelFilialCondPgto>();
            var skip = (parameters.PageNumber - 1) * parameters.PageSize;
            var list = context.RelFilialCondPgtos.ToList();

            result.Count = list.Count;

            result.Data = list
                .SortBy(parameters.OrderBy)
                .Skip(skip).Take(parameters.PageSize)
                .Join(context.Filiais, o => o.FkFilial, e => e.Codigo, (o, e) => new { Relacao = o, Filial = e.Nome })// join da filial
                .Join(context.Empresas, o => o.Relacao.FkEmpresa, e => e.Codigo, (o, e) => new { o.Relacao, o.Filial, Empresa = e.Nome })// join da filial
                .Join(context.CondPgtos, o => o.Relacao.FkCondicaoPagamento, e => e.Codigo, (o, e) => new { o.Relacao, o.Filial, o.Empresa, CondPgto = e.Descricao })// join da condicao de pagamento
                .Select(p => new RelFilialCondPgto
                {
                    FkEmpresa = p.Relacao.FkEmpresa,
                    Empresa = p.Empresa,
                    FkFilial = p.Relacao.FkFilial,
                    Filial = p.Filial,
                    FkCondicaoPagamento = p.Relacao.FkCondicaoPagamento,
                    CondicaoPagamento = p.CondPgto,
                    ValorMin = p.Relacao.ValorMin
                }).ToList();

            return result;
        }

        public RelFilialCondPgto? GetByKey(RelFilialCondPgto relacao)
        {
            return context.RelFilialCondPgtos.SingleOrDefault(o =>
                o.FkFilial == relacao.FkFilial &&
                o.FkEmpresa == relacao.FkEmpresa &&
                o.FkCondicaoPagamento == relacao.FkCondicaoPagamento);
        }

        public void Remove(RelFilialCondPgto relacao)
        {
            var relacaodb = context.RelFilialCondPgtos.SingleOrDefault(o =>
                o.FkFilial == relacao.FkFilial &&
                o.FkEmpresa == relacao.FkEmpresa &&
                o.FkCondicaoPagamento == relacao.FkCondicaoPagamento);

            context.RelFilialCondPgtos.Remove(relacaodb);
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
