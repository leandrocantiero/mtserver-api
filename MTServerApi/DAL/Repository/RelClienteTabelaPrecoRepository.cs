using Microsoft.EntityFrameworkCore;
using mtvendors_api.Models;
using mtvendors_api.Models.parameters;
using System.Collections.Generic;

namespace mtvendors_api.DAL.IRepository
{
    public class RelClienteTabelaPrecoRepository : IRelClienteTabelaPrecoRepository
    {
        private DataContext context;

        public RelClienteTabelaPrecoRepository(DataContext context)
        {
            this.context = context;
        }

        public void Insert(RelClienteTabelaPreco relacao)
        {
            context.RelClienteTabelaPrecos.Add(relacao);
        }

        public PagedResult<RelClienteTabelaPreco> Get(RelacaoParameters parameters)
        {
            var result = new PagedResult<RelClienteTabelaPreco>();
            var skip = (parameters.PageNumber - 1) * parameters.PageSize;
            var list = context.RelClienteTabelaPrecos.ToList();

            result.Count = list.Count;

            if (!String.IsNullOrEmpty(parameters.Cliente))
            {
                list = list.Join(context.Clientes, o => o.FkClienteCpfCnpj, e => e.CnpjCpf, (o, e) => new { Relacao = o, Cliente = e })
                    .Where(o => o.Cliente.RazaoSocial.ToUpper().Contains(parameters.Cliente.ToUpper()))
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
                .Join(context.Clientes, o => o.FkClienteCpfCnpj, e => e.CnpjCpf, (o, e) => new { Relacao = o, Cliente = e.RazaoSocial }) // join do cliente
                .Join(context.Empresas, o => o.Relacao.FkEmpresa, e => e.Codigo, (o, e) => new { o.Relacao, o.Cliente, Empresa = e.Nome })// join da empresa
                .Join(context.Filiais, o => o.Relacao.FkFilial, e => e.Codigo, (o, e) => new { o.Relacao, o.Cliente, o.Empresa, Filial = e.Nome })// join da filial
                .Join(context.TabelasPreco, o => o.Relacao.FkTabelaPreco, e => e.Codigo, (o, e) => new { o.Relacao, o.Cliente, o.Empresa, o.Filial, TabelaPreco = e.Descricao })// join da tabela de preco
                .Select(p => new RelClienteTabelaPreco
                {
                    FkEmpresa = p.Relacao.FkEmpresa,
                    Empresa = p.Empresa,
                    FkFilial = p.Relacao.FkFilial,
                    Filial = p.Filial,
                    FkClienteCpfCnpj = p.Relacao.FkClienteCpfCnpj,
                    Cliente = p.Cliente,
                    FkTabelaPreco = p.Relacao.FkTabelaPreco,
                    TabelaPreco = p.TabelaPreco,
                }).ToList();

            return result;
        }

        public RelClienteTabelaPreco? GetByKey(RelClienteTabelaPreco relacao)
        {
            return context.RelClienteTabelaPrecos.SingleOrDefault(o =>
                o.FkFilial == relacao.FkFilial &&
                o.FkEmpresa == relacao.FkEmpresa &&
                o.FkTabelaPreco == relacao.FkTabelaPreco &&
                o.FkClienteCpfCnpj == relacao.FkClienteCpfCnpj);
        }

        public void Remove(RelClienteTabelaPreco relacao)
        {
            var relacaodb = context.RelClienteTabelaPrecos.SingleOrDefault(o =>
                o.FkFilial == relacao.FkFilial &&
                o.FkEmpresa == relacao.FkEmpresa &&
                o.FkTabelaPreco == relacao.FkTabelaPreco &&
                o.FkClienteCpfCnpj == relacao.FkClienteCpfCnpj);

            context.RelClienteTabelaPrecos.Remove(relacaodb);
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
