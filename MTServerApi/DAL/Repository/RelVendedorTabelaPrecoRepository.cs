using Microsoft.EntityFrameworkCore;
using mtvendors_api.Models.DAO;
using mtvendors_api.Models.Helpers;
using mtvendors_api.Models.parameters;

namespace mtvendors_api.DAL.IRepository
{
    public class RelVendedorTabelaPrecoRepository : IRelVendedorTabelaPrecoRepository
    {
        private DataContext context;

        public RelVendedorTabelaPrecoRepository(DataContext context)
        {
            this.context = context;
        }

        public void Insert(RelVendedorTabelaPreco relacao)
        {
            context.RelVendedorTabelaPrecos.Add(relacao);
        }

        public PagedResult<RelVendedorTabelaPreco> Get(RelacaoParameters parameters)
        {
            var result = new PagedResult<RelVendedorTabelaPreco>();
            var skip = (parameters.PageNumber - 1) * parameters.PageSize;
            var list = context.RelVendedorTabelaPrecos.ToList();

            result.Count = list.Count;

            if (!String.IsNullOrEmpty(parameters.Vendedor))
            {
                list = list.Join(context.Vendedores, o => o.FkVendedor, e => e.Codigo, (o, e) => new { Relacao = o, Vendedor = e })
                    .Where(o => o.Vendedor.Nome.ToUpper().Contains(parameters.Vendedor.ToUpper()))
                    .Select(p => p.Relacao).ToList();
            }

            if (!String.IsNullOrEmpty(parameters.TabelaPreco))
            {
                list = list.Join(context.TabelasPreco, o => o.FkTabelaPreco, e => e.Codigo, (o, e) => new { Relacao = o, TabelaPreco = e })
                    .Where(o => o.TabelaPreco.Descricao.ToUpper().Contains(parameters.TabelaPreco.ToUpper()))
                    .Select(p => p.Relacao).ToList();
            }

            result.Data = list
                .SortBy(parameters.OrderBy)
                .Skip(skip).Take(parameters.PageSize)
                .Join(context.Vendedores, o => o.FkVendedor, e => e.Codigo, (o, e) => new { Relacao = o, Vendedor = e.Nome }) // join do vendedor
                .Join(context.Empresas, o => o.Relacao.FkEmpresa, e => e.Codigo, (o, e) => new { o.Relacao, o.Vendedor, Empresa = e.Nome })// join da empresa
                .Join(context.TabelasPreco, o => o.Relacao.FkTabelaPreco, e => e.Codigo, (o, e) => new { o.Relacao, o.Vendedor, o.Empresa, TabelaPreco = e.Descricao })// join da tabela de preco
                .Select(p => new RelVendedorTabelaPreco
                {
                    FkEmpresa = p.Relacao.FkEmpresa,
                    Empresa = p.Empresa,
                    FkVendedor = p.Relacao.FkVendedor,
                    Vendedor = p.Vendedor,
                    FkTabelaPreco = p.Relacao.FkTabelaPreco,
                    TabelaPreco = p.TabelaPreco,
                }).ToList();

            return result;
        }

        public RelVendedorTabelaPreco? GetByKey(RelVendedorTabelaPreco relacao)
        {
            return context.RelVendedorTabelaPrecos.SingleOrDefault(o =>
                o.FkEmpresa == relacao.FkEmpresa &&
                o.FkTabelaPreco == relacao.FkTabelaPreco &&
                o.FkVendedor == relacao.FkVendedor);
        }

        public void Remove(RelVendedorTabelaPreco relacao)
        {
            var relacaodb = context.RelVendedorTabelaPrecos.SingleOrDefault(o =>
                o.FkEmpresa == relacao.FkEmpresa &&
                o.FkTabelaPreco == relacao.FkTabelaPreco &&
                o.FkVendedor == relacao.FkVendedor);

            context.RelVendedorTabelaPrecos.Remove(relacaodb);
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
