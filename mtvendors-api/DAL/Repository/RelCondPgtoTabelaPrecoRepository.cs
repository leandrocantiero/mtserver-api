using Microsoft.EntityFrameworkCore;
using mtvendors_api.Models;
using mtvendors_api.Models.parameters;

namespace mtvendors_api.DAL.IRepository
{
    public class RelCondPgtoTabelaPrecoRepository : IRelCondPgtoTabelaPrecoRepository
    {
        private DataContext context;

        public RelCondPgtoTabelaPrecoRepository(DataContext context)
        {
            this.context = context;
        }

        public void Insert(RelCondPgtoTabelaPreco relacao)
        {
            context.RelCondPgtoTabelaPrecos.Add(relacao);
        }

        public PagedResult<RelCondPgtoTabelaPreco> Get(RelacaoParameters parameters)
        {
            var result = new PagedResult<RelCondPgtoTabelaPreco>();
            var skip = (parameters.PageNumber - 1) * parameters.PageSize;
            var list = context.RelCondPgtoTabelaPrecos.ToList();

            result.Count = list.Count;

            result.Data = list
                .SortBy(parameters.OrderBy)
                .Skip(skip).Take(parameters.PageSize)
                .Join(context.Vendedores, o => o.FkVendedor, e => e.Codigo, (o, e) => new { Relacao = o, Vendedor = e.Nome }) // join do vendedor
                .Join(context.Clientes, o => o.Relacao.FkClienteCnpj, e => e.CnpjCpf, (o, e) => new { o.Relacao, o.Vendedor, Cliente = e.RazaoSocial }) // join do cliente
                .Join(context.Empresas, o => o.Relacao.FkEmpresa, e => e.Codigo, (o, e) => new { o.Relacao, o.Vendedor, o.Cliente, Empresa = e.Nome })// join da empresa
                .Join(context.Filiais, o => o.Relacao.FkFilial, e => e.Codigo, (o, e) => new { o.Relacao, o.Vendedor, o.Cliente,o.Empresa, Filial = e.Nome })// join da filial
                .Join(context.TabelasPreco, o => o.Relacao.FkTabelaPreco, e => e.Codigo, (o, e) => new { o.Relacao, o.Vendedor, o.Cliente, o.Empresa, o.Filial, TabelaPreco = e.Descricao })// join da tabela de preco
                .Join(context.CondPgtos, o => o.Relacao.FkCondicaoPagamento, e => e.Codigo, (o, e) => new { o.Relacao, o.Vendedor, o.Cliente, o.Empresa, o.Filial, o.TabelaPreco, CondPgto = e.Descricao })// join da condicao de pagamento
                .Select(p => new RelCondPgtoTabelaPreco
                {
                    FkEmpresa = p.Relacao.FkEmpresa,
                    Empresa = p.Empresa,
                    FkFilial = p.Relacao.FkFilial,
                    Filial = p.Filial,
                    FkVendedor = p.Relacao.FkVendedor,
                    Vendedor = p.Vendedor,
                    FkClienteCnpj = p.Relacao.FkClienteCnpj,
                    Cliente = p.Cliente,
                    FkCondicaoPagamento = p.Relacao.FkCondicaoPagamento,
                    CondicaoPagamento = p.CondPgto,
                    FkTabelaPreco = p.Relacao.FkTabelaPreco,
                    TabelaPreco = p.TabelaPreco,
                }).ToList();

            return result;
        }

        public RelCondPgtoTabelaPreco? GetByKey(RelCondPgtoTabelaPreco relacao)
        {
            return context.RelCondPgtoTabelaPrecos.SingleOrDefault(o =>
                o.FkFilial == relacao.FkFilial &&
                o.FkEmpresa == relacao.FkEmpresa &&
                o.FkTabelaPreco == relacao.FkTabelaPreco &&
                o.FkCondicaoPagamento == relacao.FkCondicaoPagamento &&
                o.FkVendedor == relacao.FkVendedor &&
                o.FkClienteCnpj == relacao.FkClienteCnpj);
        }

        public void Remove(RelCondPgtoTabelaPreco relacao)
        {
            var relacaodb = context.RelCondPgtoTabelaPrecos.SingleOrDefault(o =>
                o.FkFilial == relacao.FkFilial &&
                o.FkEmpresa == relacao.FkEmpresa &&
                o.FkTabelaPreco == relacao.FkTabelaPreco &&
                o.FkCondicaoPagamento == relacao.FkCondicaoPagamento &&
                o.FkVendedor == relacao.FkVendedor &&
                o.FkClienteCnpj == relacao.FkClienteCnpj);

            context.RelCondPgtoTabelaPrecos.Remove(relacaodb);
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
